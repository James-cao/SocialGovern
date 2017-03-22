namespace PDL.SocialGovern.Domain.Systems
{
    public class Sys_Menu
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 父节点ID
        /// </summary>
        public int FatherID { get; set; }
        /// <summary>
        /// Url 地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public int MenuCategory { get; set; }
    }
}
