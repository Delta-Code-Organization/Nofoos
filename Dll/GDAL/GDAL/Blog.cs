using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDAL
{
    public class Blog
    {
        #region Variables
        DB db = new DB();
        #endregion

        #region Proprties
        public int ID { get; set; }
        public int Type { get; set; }
        public string ImageURL { get; set; }
        public string VideoURl { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        #endregion

        public Blog()
        {
            db = new DB();
        }
        public override string ToString()
        {
            return "KnowledgeBase";
        }

        public List<Blog> GetAll() 
        {
            return db.ExecuteList("GetAllBlogs", this.GetType(), new Dictionary<string, object>()).Cast<Blog>().ToList();
        
        }

        public void Add() 
        {

            db.Insert(this);
        
        }

        public List<Blog> Search(Dictionary<string,object> dic)
        {
         return db.Search(this.GetType(), dic).Cast<Blog>().ToList();
        }

        public void Delete() 
        {
            db.Delete(this);
        }
    }
}