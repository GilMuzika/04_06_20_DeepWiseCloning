using System;

namespace _04_06_20_DeepWiseCloning
{

  public enum AdministratorPropertyNumber
  {
           ID = 0,
           NAME = 1,
           IDENTIFIER = 2,
           USER_ID = 3
  }

  public class Administrator : IDisposable
   {
       public Int64 ID { get; set; }
       public String NAME { get; set; }
       public String IDENTIFIER { get; set; }
       public Int64 USER_ID { get; set; }
        public AirlineCompany airlineCompany { get; set; }


        public Administrator( String nAME, String iDENTIFIER, Int64 uSER_ID, AirlineCompany aIRlineCompany)
       {
           NAME = nAME;
           IDENTIFIER = iDENTIFIER;
           USER_ID = uSER_ID;
            airlineCompany = aIRlineCompany;
       }
       public Administrator()
       {
           NAME = "-=DEFAULT_STRING=-";
           IDENTIFIER = "-=DEFAULT_STRING=-";
           USER_ID = -9999;
            airlineCompany = new AirlineCompany();
       }



        public static bool operator ==(Administrator c1, Administrator c2)
        {
            if (ReferenceEquals(c1, null) && ReferenceEquals(c2, null)) return true;

            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null)) return false;

            return c1.ID == c2.ID;
        }

        public static bool operator !=(Administrator c1, Administrator c2)
        {
            return !(c1 == c2);
        }
        public override bool Equals(object obj)
        {
            var thisType = obj as Administrator;
            return this == thisType;
        }
        public override int GetHashCode()
        {
            return Convert.ToInt32(this.ID);
        }

        public override string ToString()
        {
            string str = string.Empty;
            foreach(var s in this.GetType().GetProperties())
               str += $"{ s.Name}: { s.GetValue(this)}\n";

            return str;
        }


       public void Dispose() { }

   }
}
