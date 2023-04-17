

namespace Cache.Redis.Data.Domain
{
    public class Content
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int AuthorId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Author Author { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<Category> Category { get; set; }

    }

}
