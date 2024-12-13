using System;
using System.Data;
using System.Configuration;
using System.IO;
using System.Collections;
using System.Web;
using System.Net;

/// <summary>
/// Summary description for Class1
/// </summary>
public  class ClsRg
{
    string[] NDigits = new string[20];
    string[] NTens = new string[10];
    string numstring;
    string Tnumber;
      System.Collections.ArrayList ValidateList = new ArrayList() ;
      public static Boolean IsInteger(string Value)
      {
        try
        {
            Convert.ToInt32(Value);
            return true;
        } 
        catch 
        {
            return false;
        }
      }
   public static  string   GetddMMyyyy (DateTime    Dt ) 
        {

        return (Convert.ToString(Dt.Day) + "/" + Convert.ToString(Dt.Month) + "/" + Convert.ToString(Dt.Year));
        }

    public static string GetMMddyyyy(DateTime Dt)
    {
        return (Convert.ToString(Dt.Month) + "/" + Convert.ToString(Dt.Day) + "/" + Convert.ToString(Dt.Year));
    }

    public static string GetddMMToMMdd( string Strdate  )
    {
        try
        {
            System.Globalization.DateTimeFormatInfo dtfi = new System.Globalization.DateTimeFormatInfo();
            dtfi.ShortDatePattern = "dd/MM/yyyy";
            DateTime Dt = Convert.ToDateTime(Strdate, dtfi);
            return(Convert.ToString(Dt.Month) + "/" + Convert.ToString(Dt.Day) + "/" + Convert.ToString(Dt.Year));
        }
        catch (Exception ex)
        { return null; }
    
        }

        public static string   GetMMddToddMM(string  Strdate ) 
        {
            try
             {  
                System.Globalization.DateTimeFormatInfo dtfi = new System.Globalization.DateTimeFormatInfo();
                dtfi.ShortDatePattern = "MM/dd/yyyy";
                DateTime Dt  = Convert.ToDateTime(Strdate, dtfi);
                return (Convert.ToString(Dt.Day) + "/" + Convert.ToString(Dt.Month) + "/" + Convert.ToString(Dt.Year));
             }     
            catch (Exception  ex)
            {return null;}
                
        }
        public  DateTime  GetFullDate(string  StrDate      ) 
        { return( GetFullDate(StrDate,"dd/MM/yyyy"));
        }

        public static string DateToString(DateTime Date, string Format)
        {
            System.Globalization.DateTimeFormatInfo dtfi = new System.Globalization.DateTimeFormatInfo();
            dtfi.ShortDatePattern = Format;

            string s = Convert.ToString(Date, dtfi);
            return (s);
        }

    public  DateTime  GetFullDate(string  StrDate ,  string Formate    ) 
    {  string[] Str = new string [3]; 
        Str = StrDate.Split('/');
        if ( Formate == "dd/MM/yyyy" )
        {if( Str.Length == 2 )
                StrDate = StrDate + "/" + Convert.ToString(DateTime.Now.Year );
            else if (Str.Length == 1 )
                StrDate = StrDate + "/" + Convert.ToString(DateTime.Now.Month) + "/" + Convert.ToString(DateTime .Now.Year);
        }   
        else if( Formate == "MM/dd/yyyy" )
            if( Str.Length == 2)
                StrDate = StrDate + "/" + Convert.ToString(DateTime.Now.Year);
            else if( Str.Length == 1 )
                StrDate = StrDate + "/" + Convert.ToString(DateTime.Now.Day) + "/" + Convert.ToString(DateTime.Now.Year);
    
        try
        {  System.Globalization.DateTimeFormatInfo dtfi = new System.Globalization.DateTimeFormatInfo();
            dtfi.ShortDatePattern = Formate;
            DateTime  Dt  = Convert.ToDateTime(StrDate, dtfi);
            return (Dt);
        }catch( Exception ex)
        {throw (ex )  ;}
        

        }

    public static  DateTime  ToDate(string  Strdate , string  format ) 
    {
        try
        {  System.Globalization.DateTimeFormatInfo  dtfi = new System.Globalization.DateTimeFormatInfo();
            dtfi.ShortDatePattern = format;
            return Convert.ToDateTime(Strdate, dtfi);
        }
        catch ( Exception ex)
        {      throw (ex) ;
        }

    }
    public static Boolean  IsDate(string Strdate, string format)
    {
        try
        {
            System.Globalization.DateTimeFormatInfo dtfi = new System.Globalization.DateTimeFormatInfo();
            dtfi.ShortDatePattern = format;
            DateTime D= Convert.ToDateTime(Strdate, dtfi);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    public static  bool ValidateDate(string  Strdate , string  format ) 
    {
        try
        {  System.Globalization.DateTimeFormatInfo  dtfi = new System.Globalization.DateTimeFormatInfo();
            dtfi.ShortDatePattern = format;
            DateTime  dt  = DateTime.Parse  (Strdate,  dtfi);
        }catch  (Exception ex)
        {  return false;}
        
        return true;
    }
    
    public static  int GetFinanceYear(DateTime   Dt ) 
    {if (Dt.Month <= 3 )
            return Dt.Year - 1;
        else
            return Dt.Year;
    }

  public static void DeleteFromFtp(string Path)
    {
        FtpWebRequest myFtpWebRequest;
        FtpWebResponse myFtpWebResponse;
        myFtpWebRequest = (FtpWebRequest)FtpWebRequest.Create("ftp://Chittorgarhonline.in/wwwroot/News/" +Path  );
        myFtpWebRequest.Credentials = new NetworkCredential("Chittorgarhonline", "bol707");
        myFtpWebRequest.Method = WebRequestMethods.Ftp.DeleteFile;
        myFtpWebResponse = (FtpWebResponse)myFtpWebRequest.GetResponse();
        //  litResponse.Text = myFtpWebResponse.StatusDescription;
        myFtpWebResponse.Close();
    }
    public static void CreateFtpDirectory(string Path)
    {
            FtpWebRequest myFtpWebRequest;
            FtpWebResponse myFtpWebResponse;
            myFtpWebRequest = (FtpWebRequest)FtpWebRequest.Create( "ftp://Chittorgarhonline.in/wwwroot/News/" + Path  );
            myFtpWebRequest.Credentials = new NetworkCredential("Chittorgarhonline", "bol707");
            myFtpWebRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
            myFtpWebResponse = (FtpWebResponse)myFtpWebRequest.GetResponse();
            myFtpWebResponse.Close();
    }



//    public string Number2String(double Mnum)
//   { long Tenth, LeftOver, Hundred, Thousand, Tth, Lakh, Crore, DumNum ;
//        object  Paisa;

//        NDigits[1] = "One";
//        NDigits[2] = "Two";
//        NDigits[3] = "Three";
//        NDigits[4] = "Four";
//        NDigits[5] = "Five";
//        NDigits[6] = "Six";
//        NDigits[7] = "Seven";
//        NDigits[8] = "Eight";
//        NDigits[9] = "Nine";
//        NDigits[10] = "Ten";
//        NDigits[11] = "Eleven";
//        NDigits[12] = "Twelve";
//        NDigits[13] = "Thirteen";
//        NDigits[14] = "Fourteen";
//        NDigits[15] = "Fifteen";
//        NDigits[16] = "Sixteen";
//        NDigits[17] = "Seventeen";
//        NDigits[18] = "Eighteen";
//        NDigits[19] = "Nineteen";

//        NTens[2] = "Twenty";
//        NTens[3] = "Thirty";
//        NTens[4] = "Forty";
//        NTens[5] = "Fifty";
//        NTens[6] = "Sixty";
//        NTens[7] = "Seventy";
//        NTens[8] = "Eighty";
//        NTens[9] = "Ninety";


//   int caseSwitch = 1;
//switch (caseSwitch)
//{
//    case 1  : 
//    case 3:
//        Console.WriteLine("Case 1");
//        break;
//    case 2:
//        Console.WriteLine("Case 2");
//        break;
//    default:
//        Console.WriteLine("Default case");
//        break;
//}


//        if( Mnum > 0 )
//        { Paisa = Convert .ToInt32 (Mnum) - (int) Mnum;
//            Mnum = Convert .ToUInt32 (Mnum);
//            DumNum =(long) Mnum;
//           if (Mnum<=19)
//           {
//                    numstring = ReadSingle(Mnum);
//           }
//            else if (Mnum>= 20 && Mnum <= 99)
//           {        Tenth = (int)(Mnum / 10);
//                    numstring = ReadTenths(Tenth * 10);
//                    LeftOver = (long)Mnum - (Tenth * 10);
//                    if (LeftOver > 0)
//                        numstring = numstring + " " + ReadSingle(LeftOver);
//            }
//           else if(Mnum>= 100 && Mnum<= 999)
//           {        Hundred = (int)(Mnum / 100);
//                    numstring = ReadSingle(Hundred) + " Hundred";
//                    LeftOver = (long )Mnum - (Hundred * 100);
//                    if (LeftOver > 0 )
//                    {   if (LeftOver < 20 )
//                                numstring = numstring + " " + ReadSingle(LeftOver);
//                         else
//                         {   Tenth = Int(LeftOver / 10);
//                                if (Tenth > 0)
//                                    numstring = numstring + " " + ReadTenths(Tenth * 10);
//                                LeftOver = (long )Mnum - (Hundred * 100) - (Tenth * 10);
//                                if (LeftOver > 0)
//                                    numstring = numstring + " " + ReadSingle(LeftOver);
//                         }
//                    }
//           }
//           else if (Mnum>= 1000 && Mnum<= 99999)
//           {        Thousand = (int)(Mnum / 1000);
//                    if( Thousand < 20 )
//                        numstring = ReadSingle(Thousand) + " Thousand";
//                    else
//                    {   Tth = Int(Thousand / 10);
//                        numstring = ReadTenths(Tth * 10);
//                        Tenth = Thousand - (Tth * 10);
//                        if (Tenth > 0 )
//                            numstring = numstring + " " +k ReadSingle(Tenth) + " Thousand";
//                        else
//                            numstring = ReadTenths(Tth * 10) + " Thousand";
                        
//                    }
//                    LeftOver = (long )Mnum - Thousand * 1000;
//                    if( LeftOver > 0 )
//                    {Hundred = (int)(LeftOver / 100);
//                        if (Hundred > 0 )
//                            numstring = numstring + " " + ReadSingle(Hundred) + " Hundred";
//                        LeftOver = (long )Mnum - (Thousand * 1000) - (Hundred * 100);
//                        if( LeftOver > 0 )
//                        {       if (LeftOver < 20 )
//                                numstring = numstring + " " + ReadSingle(LeftOver);
//                                else
//                                {   Tenth = (int)(LeftOver / 10);
//                                    if( Tenth > 0 ) 
//                                        numstring = numstring + " " + ReadTenths(Tenth * 10);
//                                    LeftOver = (long )Mnum - (Thousand * 1000) - (Hundred * 100) - (Tenth * 10);
//                                    if (LeftOver > 0 )
//                                        numstring = numstring + " " + ReadSingle(LeftOver);
//                                 }
//                         }
//                    }
//           }
//           else if(Mnum>= 100000 && Mnum<= 9999999)
//           {        Lakh = (int)(Mnum / 100000);
//                    if( Lakh > 0 )
//                    {   if( Lakh < 20 )
//                            numstring = ReadSingle(Lakh) + " Lakh";
//                        else
//                        {   Tth = (int)(Lakh / 10);
//                            numstring = ReadTenths(Tth * 10);
//                            Tenth = Lakh - (Tth * 10);
//                            if( Tenth > 0 )
//                                numstring = numstring + " " + ReadSingle(Tenth) + " Lakh";
//                            else
//                                numstring = ReadTenths(Tth * 10) + " Lakh";
                            
//                        }
//                        LeftOver = (long )Mnum - (Lakh * 100000);
//                    }
//                    if( LeftOver > 0 )
//                    {   Mnum = LeftOver;
//                        Thousand = (int)(Mnum / 1000);
//                        if( Thousand > 0 )
//                        {   if (Thousand < 20 )
//                                numstring = numstring + " " + ReadSingle(Thousand) + " Thousand";
//                            else
//                            {   Tth = (int)(Thousand / 10);
//                                Tenth = Thousand - (Tth * 10);
//                                if( Tenth > 0 )
//                                    numstring = numstring + " " + ReadTenths(Tth * 10) + " " + ReadSingle(Tenth) + " Thousand";
//                                else
//                                    numstring = numstring + " " + ReadTenths(Tth * 10) + " Thousand";
                                
//                            }
//                        }
//                        LeftOver = (long )Mnum - (Thousand * 1000);
//                        if( LeftOver > 0 )
//                        {   Hundred = (int)(LeftOver / 100);
//                            if( Hundred > 0 )
//                                numstring = numstring + " " + ReadSingle(Hundred) + " Hundred";
//                            LeftOver = (long )Mnum - (Thousand * 1000) - (Hundred * 100);
//                            if( LeftOver > 0 )
//                            {   if (LeftOver < 20 )
//                                    numstring = numstring + " " + ReadSingle(LeftOver);
//                                else
//                                {   Tenth = (int)(LeftOver / 10);
//                                    if( Tenth > 0 )
//                                        numstring = numstring + " " + ReadTenths(Tenth * 10);
//                                    LeftOver = (long )Mnum - (Thousand * 1000) - (Hundred * 100) - (Tenth * 10);
//                                    if (LeftOver > 0 )
//                                        numstring = numstring + " " + ReadSingle(LeftOver);
//                                }
//                            }
//                        }
//                    }
//           }
//           else if (Mnum>= 10000000 && Mnum <=999999999)
//           {        Crore = (int)(Mnum / 10000000);
//                    if( Crore > 0 )
//                    {   if( Crore < 20 )
//                            numstring = ReadSingle(Crore) + " Crore";
//                        else
//                        {   Tth = (int)(Crore / 10);
//                            numstring = ReadTenths(Tth * 10);
//                            Tenth = Crore - (Tth * 10);
//                            if( Tenth > 0 )
//                                numstring = numstring + " " + ReadSingle(Tenth) + " Crore";
//                            else
//                                numstring = ReadTenths(Tth * 10) + " Crore";
                            
//                        }
//                        LeftOver = (long )Mnum - (Crore * 10000000);
//                    }
//                    Mnum = LeftOver;
//                    Lakh = (int)(Mnum / 100000);
//                    if( Lakh > 0 )
//                    {   if( Lakh < 20 )
//                            numstring = numstring + " " + ReadSingle(Lakh) + " Lakh";
//                        else
//                        {   Tth = (int)(Lakh / 10);
//                            numstring = numstring + " " + ReadTenths(Tth * 10);
//                            Tenth = Lakh - (Tth * 10);
//                            if (Tenth > 0 )
//                                numstring = numstring + " " + ReadSingle(Tenth) + " Lakh";
//                            else
//                                numstring = numstring + " " + ReadTenths(Tth * 10) + " Lakh";
                            
//                        }
//                        LeftOver = (long )Mnum - (Lakh * 100000);
//                    }
//                    if( LeftOver > 0 )
//                    {   Mnum = LeftOver;
//                        Thousand = (int)(Mnum / 1000);
//                        if( Thousand > 0 )
//                        {   if (Thousand < 20 )
//                                numstring = numstring + " " + ReadSingle(Thousand) + " Thousand";
//                            else
//                            {   Tth = (int)(Thousand / 10);
//                                Tenth = Thousand - (Tth * 10);
//                                if (Tenth > 0 )
//                                    numstring = numstring + " " + ReadTenths(Tth * 10) + " " + ReadSingle(Tenth) + " Thousand";
//                                else
//                                    numstring = numstring + " " + ReadTenths(Tth * 10) + " Thousand";
                                
//                            }
//                        }
//                        LeftOver = (long )Mnum - (Thousand * 1000);
//                        if( LeftOver > 0 )
//                        {   Hundred = (int)(LeftOver / 100);
//                            if( Hundred > 0 )
//                                numstring = numstring + " " + ReadSingle(Hundred) + " Hundred";
//                            LeftOver = (long )Mnum - (Thousand * 1000) - (Hundred * 100);
//                            if (LeftOver > 0 )
//                            {   if( LeftOver < 20 )
//                                    numstring = numstring + " " + ReadSingle(LeftOver);
//                                else
//                                {   Tenth = (int)(LeftOver / 10);
//                                    if (Tenth > 0 )
//                                        numstring = numstring + " " + ReadTenths(Tenth * 10);
//                                    LeftOver = (long )Mnum - (Thousand * 1000) - (Hundred * 100) - (Tenth * 10);
//                                    if (LeftOver > 0 )
//                                        numstring = numstring + " " + ReadSingle(LeftOver);
//                                }
//                            }
//                        }
//                    }
//           }
            
//            if( DumNum == 0 )
//                numstring = "";
//            else if(Convert .ToInt32 (  Paisa) != 0 )
//                numstring = numstring + " and ";
            
//            if(Convert .ToInt32 ( Paisa )!= 0 )
//            {   Paisa = Paisa * 100;
//                if( Convert .ToInt32 ( Paisa) < 20 )
//                    numstring = numstring + ReadSingle(Paisa) + " paisa";
//                else
//                {   Tth = (int)(Paisa / 10);
//                    Tenth =Convert .ToInt32 ( Paisa) - (Tth * 10);
//                    if( Tenth > 0 )
//                        numstring = numstring + ReadTenths(Tth * 10) + " " + ReadSingle(Tenth) + " paisa";
//                    else
//                        numstring = numstring + ReadTenths(Tth * 10) + " paisa";
                    
//                }
//            }
//            numstring = numstring + " Only.";
//        }
//            else
//            numstring = " Nill ";
        
//        numstring = UCase(numstring.Substring ( 1)) + System .Math . Mid(numstring, 2, Len(numstring) - 1);
//        Number2String = numstring;
//   }



//    private string ReadSingle(object Number)
//    {
//        if (Number > 0 && Number < 20)
//            ReadSingle = NDigits(Number);
//        else
//            ReadSingle = "*****";

//    }

//    private string ReadTenths(object Number)
//    {
//        tnumber = Int(Number / 10);
//        if (tnumber > 1 && tnumber < 10)
//            ReadTenths = NTens(tnumber);
//        else
//            ReadTenths = "*****";

//    }
}
