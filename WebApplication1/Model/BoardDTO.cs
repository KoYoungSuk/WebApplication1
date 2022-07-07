using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class BoardDTO
    {
        int serial;
        String title;
        String content;
        String savedate;
        String modifydate;
        String userid;
        String anonymous;
        int clicks;

        public BoardDTO()
        {

        }
        public BoardDTO(int serial, string title, string content, String savedate, String modifydate, string userid, string anonymous, int clicks)
        {
            this.Serial = serial;
            this.Title = title;
            this.Content = content;
            this.Savedate = savedate;
            this.Modifydate = modifydate;
            this.Userid = userid;
            this.Anonymous = anonymous;
            this.Clicks = clicks;
        }
        public int Serial { get => serial; set => serial = value; }
        public string Title { get => title; set => title = value; }
        public string Content { get => content; set => content = value; }
        public string Savedate { get => savedate; set => savedate = value; }
        public string Modifydate { get => modifydate; set => modifydate = value; }
        public string Userid { get => userid; set => userid = value; }
        public string Anonymous { get => anonymous; set => anonymous = value; }
        public int Clicks { get => clicks; set => clicks = value; }
    }
}