using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;
using System.Security.Cryptography;

namespace TMXConverter
{
    class Program
    {

        struct TMXByte
        {
            internal byte alpha;
            internal byte red;
            internal byte green;
            internal byte blue;

            public TMXByte(Color color)
            {
                alpha = color.A;
                red = color.R;
                green = color.G;
                blue = color.B;
            }
        }
        static void Main(string[] args)
        {

            if (args.Length == 0)
            {
                Console.WriteLine("usage: TMXConverter imagefile(png, jpeg, bmp) [output.tmx]");
            }
            else
            {
                string input = args[0];
                string output;
                if (args.Length >= 2)
                    output = args[1];
                else output = Path.ChangeExtension(input, "tmx");

                Bitmap image = new Bitmap(input, true);
                Color[] tmxbyte = new Color[image.Width * image.Height];
                int num = 0;

                for (int y = 0; y < image.Height; y += 1)
                {
                    for (int x = 0; x + 7 < image.Width; x += 8)
                    {
                        tmxbyte[num] = image.GetPixel(x, y);
                        tmxbyte[num + 1] = image.GetPixel(x + 1, y);
                        tmxbyte[num + 2] = image.GetPixel(x + 2, y);
                        tmxbyte[num + 3] = image.GetPixel(x + 3, y);
                        tmxbyte[num + 4] = image.GetPixel(x + 4, y);
                        tmxbyte[num + 5] = image.GetPixel(x + 5, y);
                        tmxbyte[num + 6] = image.GetPixel(x + 6, y);
                        tmxbyte[num + 7] = image.GetPixel(x + 7, y);
                        num += 8;


                    }
                }
                using (var fs = new FileStream(output, FileMode.Create, FileAccess.Write))
                {
                    BinaryWriter bw = new BinaryWriter(fs);
                    bw.Write(0x00010002);
                    bw.Write(64 + (4 * tmxbyte.Length));
                    bw.Write(0x30584D54); //TMX0
                    bw.Seek(6, SeekOrigin.Current);
                    bw.Write((short)(image.Width - (image.Width % 8)));
                    bw.Write((short)(image.Height - (image.Height % 2)));
                    bw.Write(0xFF0000000000);
                    bw.Seek(34, SeekOrigin.Current);
                    for (int i = 0; i < tmxbyte.Length; i++)
                    {
                        bw.Write((byte)((tmxbyte[i].R)));
                        bw.Write((byte)((tmxbyte[i].G)));
                        bw.Write((byte)((tmxbyte[i].B)));
                        bw.Write((byte)((tmxbyte[i].A * 128/255)));

                    }

                }
            }
            
        }
    }
}