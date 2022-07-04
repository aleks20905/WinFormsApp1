using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormUI {
    public static class Helper {
        private static string Host = "localhost";
        private static string User = "postgres";
        private static string DBname = "traindb";
        private static string Password = "123";
        private static string Port = "5432";

        private static string connString =
               String.Format(
                   "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                   Host,
                   User,
                   DBname,
                   Port,
                   Password);
        public static string ConnString() {
            return connString;
        }
    }
}