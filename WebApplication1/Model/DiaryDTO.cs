using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class DiaryDTO
    {
        String title;
        String context;
        String savedate;
        String modifydate;

        public DiaryDTO()
        {

        }
        public DiaryDTO(string title, string context, string savedate, string modifydate)
        {
            this.Title = title;
            this.Context = context;
            this.Savedate = savedate;
            this.Modifydate = modifydate;
        }

        public string Title { get => title; set => title = value; }
        public string Context { get => context; set => context = value; }
        public string Savedate { get => savedate; set => savedate = value; }
        public string Modifydate { get => modifydate; set => modifydate = value; }
    }
}