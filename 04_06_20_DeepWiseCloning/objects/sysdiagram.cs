using System;

namespace _04_06_20_DeepWiseCloning
{

  public enum sysdiagramPropertyNumber
  {
           name = 0,
           principal_id = 1,
           diagram_id = 2,
           version = 3,
           definition = 4
  }

  public class sysdiagram : IDisposable
   {
       public String name { get; set; }
       public Int32 principal_id { get; set; }
       public Int32 diagram_id { get; set; }
       public Int32 version { get; set; }
       public Byte[] definition { get; set; }


       public sysdiagram( Int32 pRINCIPAL_ID, Int32 dIAGRAM_ID, Int32 vERSION, Byte[] dEFINITION)
       {
           principal_id = pRINCIPAL_ID;
           diagram_id = dIAGRAM_ID;
           version = vERSION;
           definition = dEFINITION;
       }
       public sysdiagram()
       {
           principal_id = -9999;
           diagram_id = -9999;
           version = -9999;
           definition = new Byte[] { 0x20 };
       }



        public static bool operator ==(sysdiagram c1, sysdiagram c2)
        {
            if (ReferenceEquals(c1, null) && ReferenceEquals(c2, null)) return true;

            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null)) return false;

            return c1.name == c2.name;
        }

        public static bool operator !=(sysdiagram c1, sysdiagram c2)
        {
            return !(c1 == c2);
        }
        public override bool Equals(object obj)
        {
            var thisType = obj as sysdiagram;
            return this == thisType;
        }
        public override int GetHashCode()
        {
            return Convert.ToInt32(this.name);
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
