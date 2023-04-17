

namespace Cache.Redis.Data.Domain
{
    public class Category 
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<Content> Content { get; set; }
    }
}
