﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace PruebaCamiloBautista.Dominio.Tools
{
    public class Encrypt
    {
        //metodo para encriptar en sha256
        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
