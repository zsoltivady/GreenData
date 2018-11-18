using GreenDraw.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Data.Entity;
using GreenDraw.Model;
using System.Security.Cryptography;
using System.Windows;
using System.ComponentModel;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace GreenDraw.ViewModel
{
    public class LoginListViewModel
    {
        greendrawEntities db = new greendrawEntities();
        public List<LoginLog> LogList
        {
            get
            {
                var logs = db.LoginLog.OrderBy(log => log.DateTime).Skip(0).Take(10).ToList();
                return logs;
            }
        }
    }
}
