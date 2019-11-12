using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace EncryptDecryptTest
{


    class Program
    {
        private static byte[] Sign(byte[] data)
        {
            X509Certificate2 cert = LoadPrivateKey();
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            if (cert == null)
            {
                throw new ArgumentNullException("privateKey");
            }
            if (!cert.HasPrivateKey)
            {
                throw new ArgumentException("invalid certificate", "privateKey");
            }
            var provider = (RSACryptoServiceProvider)cert.PrivateKey;
            return provider.SignData(data, new SHA1CryptoServiceProvider());
        }
        private static bool Verify(byte[] data, byte[] signature)
        {
            X509Certificate2 cert = LoadPublicKey();
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            if (cert == null)
            {
                throw new ArgumentNullException("publicKey");
            }
            if (signature == null)
            {
                throw new ArgumentNullException("signature");
            }
            var provider = (RSACryptoServiceProvider)cert.PublicKey.Key;
            return provider.VerifyData(data, new SHA1CryptoServiceProvider(), signature);
        }
        private static X509Certificate2 LoadPrivateKey()
        {
            return new X509Certificate2(@"D:\cert.p12", "Dragon1997");
        }
        private static X509Certificate2 LoadPublicKey()
        {
            return new X509Certificate2(@"D:\cert.pem");
        }
        public static bool VerifyImages(byte[] imageBytes)
        {
            try
            {
                List<byte[]> imageWithSignature = ByteArrayToListByteArray(imageBytes);
                if (imageWithSignature.Count != 2)
                {
                    return false;
                }
                byte[] orignalImages = imageWithSignature[0];
                byte[] signature = imageWithSignature[1];
                if (orignalImages == null || signature == null)
                {
                    return false;
                }
                return Verify(orignalImages, signature);
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static byte[] signImages(List<Bitmap> imgs)
        {
            byte[] originalImage = ObjToByteArray(imgs);
            byte[] signature = Sign(originalImage);
            List<byte[]> imageWithSignature = new List<byte[]>();
            imageWithSignature.Add(originalImage);
            imageWithSignature.Add(signature);
            return ObjToByteArray(imageWithSignature);
        }
        static void Main(string[] args)
        {
            //Bitmap images = new Bitmap(@"D:\graduation thesis\templates\Testing\OUT\Testing.tif");
            //List<Bitmap> lstImgs = GetAllPage(images);
            //File.WriteAllBytes(@"D:\graduation thesis\templates\Testing\OUT\Ans.enc", signImages(lstImgs));


            byte[] encryptedImg = File.ReadAllBytes(@"D:\graduation thesis\templates\Testing\OUT\Ans.dat");
            bool verifyingResult = VerifyImages(encryptedImg);
            Console.Read();
        }
        public static List<Bitmap> ByteArrayToListBitmap(byte[] data)
        {
            var mStream = new MemoryStream();
            var binFormatter = new BinaryFormatter();
            mStream.Write(data, 0, data.Length);
            mStream.Position = 0;
            return binFormatter.Deserialize(mStream) as List<Bitmap>;
        }
        public static List<byte[]> ByteArrayToListByteArray(byte[] data)
        {
            var mStream = new MemoryStream();
            var binFormatter = new BinaryFormatter();
            mStream.Write(data, 0, data.Length);
            mStream.Position = 0;
            return binFormatter.Deserialize(mStream) as List<byte[]>;
        }
        public static byte[] ObjToByteArray(Object data)
        {
            var binFormatter = new BinaryFormatter();
            var mStream = new MemoryStream();
            binFormatter.Serialize(mStream, data);
            return mStream.ToArray();
        }
        public static void createDemoTif()
        {
            string[] files = Directory.GetFiles(@"D:\graduation thesis\templates\Testing\INP\", "*.jpg", SearchOption.TopDirectoryOnly);
            List<Image> lstImages = new List<Image>();
            foreach (string file in files)
            {
                lstImages.Add(Image.FromFile(file));
            }
            createTif(lstImages.ToArray(), @"D:\graduation thesis\templates\Testing\OUT\Testing.tif");
        }
        public static List<Bitmap> GetAllPage(Bitmap bitmap)
        {
            List<Bitmap> imgs = new List<Bitmap>();
            int count = bitmap.GetFrameCount(FrameDimension.Page);
            for (int curPage = 0; curPage < count; curPage++)
            {
                bitmap.SelectActiveFrame(FrameDimension.Page, curPage); // going to the selected page
                Bitmap currentImage = new Bitmap(bitmap);
                imgs.Add(currentImage);
            }
            return imgs;
        }
        public static void PrintBytes(byte[] bytes)
        {
            int nOfBytes = 0;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (Int32 i = 0; i < bytes.Length; i++)
            {
                nOfBytes++;
                sb.Append(string.Format("{0:X2} ", bytes[i]));
            }
            Console.WriteLine(sb.ToString());
            Console.WriteLine(nOfBytes);
        }
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            for (int j = 0; j < encoders.Length; j++)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }

            throw new Exception(mimeType + " mime type not found in ImageCodecInfo");
        }
        public static bool createTif(Image[] bmp, string location)
        {
            if (bmp != null)
            {
                try
                {
                    ImageCodecInfo codecInfo = GetEncoderInfo("image/tiff");
                    if (bmp.Length == 1)
                    {
                        EncoderParameters iparams = new EncoderParameters(1);
                        Encoder iparam = Encoder.Compression;
                        EncoderParameter iparamPara = new EncoderParameter(iparam, (long)(EncoderValue.CompressionLZW));
                        iparams.Param[0] = iparamPara;
                        bmp[0].Save(location, codecInfo, iparams);
                    }
                    else if (bmp.Length > 1)
                    {

                        Encoder saveEncoder;
                        Encoder compressionEncoder;
                        EncoderParameter SaveEncodeParam;
                        EncoderParameter CompressionEncodeParam;
                        EncoderParameters EncoderParams = new EncoderParameters(2);

                        saveEncoder = Encoder.SaveFlag;
                        compressionEncoder = Encoder.Compression;

                        // Save the first page (frame).
                        SaveEncodeParam = new EncoderParameter(saveEncoder, (long)EncoderValue.MultiFrame);
                        CompressionEncodeParam = new EncoderParameter(compressionEncoder, (long)EncoderValue.CompressionLZW);
                        EncoderParams.Param[0] = CompressionEncodeParam;
                        EncoderParams.Param[1] = SaveEncodeParam;

                        File.Delete(location);
                        bmp[0].Save(location, codecInfo, EncoderParams);


                        for (int i = 1; i < bmp.Length; i++)
                        {
                            if (bmp[i] == null)
                                break;

                            SaveEncodeParam = new EncoderParameter(saveEncoder, (long)EncoderValue.FrameDimensionPage);
                            CompressionEncodeParam = new EncoderParameter(compressionEncoder, (long)EncoderValue.CompressionLZW);
                            EncoderParams.Param[0] = CompressionEncodeParam;
                            EncoderParams.Param[1] = SaveEncodeParam;
                            bmp[0].SaveAdd(bmp[i], EncoderParams);

                        }

                        SaveEncodeParam = new EncoderParameter(saveEncoder, (long)EncoderValue.Flush);
                        EncoderParams.Param[0] = SaveEncodeParam;
                        bmp[0].SaveAdd(EncoderParams);
                    }
                }
                catch (System.Exception ee)
                {
                    throw new Exception(ee.Message + " Merge image error");
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
