using System.Drawing;
using System.IO;

namespace AutoPictureCut.Helper
{
    public class ImgHelper
    {
        /// <summary>
        /// 合成为图片
        /// </summary>
        /// <param name="MainPicturePath">要处理的图片</param>
        /// <param name="BackgroundPicturePath">衬托的图片</param>
        /// <param name="CurrentPicture">要合成的第几个图片</param>
        /// <exception cref="Exception"></exception>
        public static string CombineImage(string MainPicturePath, string BackgroundPicturePath, int CurrentPicture)
        {
            int imageWidth = 400;  // 每个小图片的宽度
            int imageHeight = 400; // 每个小图片的高度
            int gap = 10;          // 每个图片之间的空隙
            string savePath = string.Empty;
            // 最终合成图片的大小
            int finalWidth = imageWidth * 3 + gap * 2;
            int finalHeight = imageHeight * 3 + gap * 2;
            //得到当前数量的字典
            var currentPictureDic = MapperHelper.BackgroundPictureDic.FirstOrDefault(m => m.Key == CurrentPicture);
            if (currentPictureDic.Key == default(Int32))
            {
                throw new Exception("当前数量没对应的图片位置字典");
            }
            // 创建最终图像
            using (Bitmap finalImage = new Bitmap(finalWidth, finalHeight))
            using (Graphics g = Graphics.FromImage(finalImage))
            {
                g.Clear(Color.White); // 设置背景为黑色
                string imgPath = string.Empty;
                // 加载并绘制每张小图片
                for (int i = 0; i < 9; i++)
                {
                    if (currentPictureDic.Value == null)
                    {
                        imgPath = MainPicturePath;
                    }
                    else
                        imgPath = currentPictureDic.Value.Contains(i) ? BackgroundPicturePath : MainPicturePath;
                    int x = (i % 3) * (imageWidth + gap);
                    int y = (i / 3) * (imageHeight + gap);

                    using (Bitmap image = new Bitmap(imgPath))
                    {
                        g.DrawImage(image, x, y, imageWidth, imageHeight);
                    }
                }
                string saveFolder = Path.Combine(Environment.CurrentDirectory, "Image");
                if (!Directory.Exists(saveFolder)) Directory.CreateDirectory(saveFolder);
                savePath = Path.Combine(saveFolder, $"{CurrentPicture}-combined_image{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.jpg");
                // 保存最终图像
                finalImage.Save(savePath);
            }

            return savePath;
        }
    }
}
