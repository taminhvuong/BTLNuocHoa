using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTLNuocHoa
{
    public partial class dangnhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<user> danhsach;
            danhsach = (List<user>)Application["danhsach_us"];
            string email = Request.Form["email"];
            string hoten = Request.Form["hoten"];
            string pass = Request.Form["pass"];
            if (danhsach.Count == 0)
            {

            }
            else
            {
                foreach (user us in danhsach)
                {
                    if (us.Email == email && us.Pass == pass)
                    {
                        Session["dangnhap"] = 1;
                        //thời gian khi user đăng nhập
                        Session["datetime"] = DateTime.Now;
                        Session["email"] = us.Email;
                        //Khởi tạo application kiểm tra thời gian chạy của user
                       Application["tk"] = us.Email;
                        Session["hoten"] = us.HoTen;
                        Session["pass"] = us.Pass;
                        Response.Redirect("trangchu.aspx");
                    }
                    // đăng nhập sai 3 lần ẩn nút đ nhập
                    else if (us.Email == email && us.Pass != pass)
                    {
                        if (Session["dem"] == null)
                        {
                            Session["dem"] = 1;
                        }
                        else
                        {
                            Session["dem"] = (int)Session["dem"] + 1;
                        }
                        if ((int)Session["dem"] >= 3)
                        {
                            Session["dem"] = null;
                            dn.Visible = false;
                            saimk.InnerHtml = ("Bạn đăng nhập sai 3 lần bị khóa");
                        }

                        else
                        {
                            saimk.InnerHtml = ("Bạn đăng nhập sai lần thứ: " + Session["dem"]);
                        }
                    }
                }

            }
            }
        }
    }
