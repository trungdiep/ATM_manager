﻿using DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALs
{
    public class CardDAL
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ToString()); 
        public CardDTO getValidCard(string pin)
        {
            try
            {
                conn.Open();
                string query = "SELECT tblCard.*, tblAccount.CustID, tblCustomer.Name FROM tblCard, tblAccount, tblCustomer WHERE tblCard.PIN=@mapin AND tblCard.AccountID = tblAccount.AccountID AND tblAccount.CustID = tblCustomer.CustID";
                //string query = "SELECT tblCard.*, tblCustomer.Name"
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("mapin", pin);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                CardDTO card = new CardDTO(
                    dr["CardNO"].ToString(),
                    int.Parse(dr["Status"].ToString()),
                    dr["Name"].ToString(),
                    dr["PIN"].ToString(),
                    dr["StartDate"].ToString(),
                    dr["ExpiredDate"].ToString(),
                    int.Parse(dr["Attempt"].ToString()));
                return card;
            }
            catch (Exception)
            {
                //throw;
                return null;
            }
        }
    }
}
