namespace AutoPictureCut.Helper
{
    public class MapperHelper
    {
        /// <summary>
        /// 衬托图片位置字典 位置从1开始算
        /// </summary>
        public static Dictionary<int, List<int>?> BackgroundPictureDic = new Dictionary<int, List<int>?>()
        {
            { 1,new List<int>{0,1,2,3,4,6} },
            { 2,new List<int>{0,1,2,4} },
            { 3,new List<int>{0,1,2,4,5,8} },
            { 4,null },
            { 5,null },
            { 6,new List<int>{8} },
            { 7,new List<int>{0,1,3,4,5,6,7,8} },
            { 8,new List<int>{6,8} },
            { 9,new List<int>{1,2,3,4,5,6,7,8} }
        };
    }
}
