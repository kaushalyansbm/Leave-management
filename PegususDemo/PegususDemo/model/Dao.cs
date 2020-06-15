using System;   

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace PegususDemo.model
{
    class Dao
    {
        MySqlConnection myCon = null;
        MySqlDataReader myReader = null;
        MySqlCommand selectCommand = null;



        public void Connect()
        {
            string myConnection = "datasource=localhost;port=3306;username=root;password=kaushalya";
            myCon = new MySqlConnection(myConnection);

        }
        public void Disconnect()
        {
            myCon.Close();


        }

        public int LogEmployee(Employee emp)
        {

            selectCommand = new MySqlCommand("select *from Aurora.Employee where id='" + emp.Id + "' and password='" + emp.Password + "';", myCon);
            myCon.Open();
            myReader = selectCommand.ExecuteReader();
            int count = 0;
            while (myReader.Read())
            {
                count++;
                return count;


            }

            return count;
        }
        public int LogAdmin(Admin ad)
        {

            selectCommand = new MySqlCommand("select *from Aurora.Admin where id='" + ad.Id + "' and password='" + ad.Password + "';", myCon);
            myCon.Open();
            myReader = selectCommand.ExecuteReader();
            int count = 0;
            while (myReader.Read())
            {
                count++;
                return count;

            }

            return count;


        }
        public int LogManager(Manager manager)
        {
            

            selectCommand = new MySqlCommand("select *from Aurora.Manager where id='" + manager.Id + "' and password='" + manager.Password + "';", myCon);
            myCon.Open();
            myReader = selectCommand.ExecuteReader();
            int count = 0;
            while (myReader.Read())
            {
                count++;
                return count;

            }
            return count;
        }

        public void EnterEmployee(Employee em)

        {
            byte[] imageBt = null;
            FileStream fs = new FileStream(em.imageE, FileMode.Open, FileAccess.Read);
            BinaryReader bi = new BinaryReader(fs);
            imageBt = bi.ReadBytes((int)fs.Length);
            selectCommand = new MySqlCommand("insert into Aurora.Employee(id,firstname,lastname,password,department,designation,telephone,email,gender,address,mobile,marriage,numberchild,image)values('" + em.Id + "','" + em.FirstName + "','" + em.LastName + "','" + em.Password + "','" +em.Department + "','" + em.Designation + "','" +em.Telephone + "','" +em.Email + "','" + em.Gender + "','" + em.Address + "','" + em.Mobile + "','" +em.Marriage + "','" + em.NumberOfChild + "',@IMG);", myCon);
            myCon.Open();

            selectCommand.Parameters.Add(new MySqlParameter("@IMG", imageBt));

            myReader = selectCommand.ExecuteReader();
        }
        public void EnterManager(Manager mana)

        {
            try{
                byte[] imageBt = null;
            FileStream fs = new FileStream(mana.image, FileMode.Open, FileAccess.Read);
            BinaryReader bi = new BinaryReader(fs);
            imageBt = bi.ReadBytes((int)fs.Length);
            selectCommand = new MySqlCommand("insert into Aurora.Manager(id,firstname,lastname,password,department,designation,telephone,email,gender,address,mobile,marriage,numberchild,image)values('" + mana.Id+ "','" + mana.FirstName + "','" + mana.LastName + "','" + mana.Password + "','" + mana.Department + "','" + mana.Designation + "','" + mana.Telephone + "','" + mana.Email + "','" + mana.Gender + "','" + mana.Address + "','" + mana.Mobile + "','" +mana.Marriage + "','" + mana.NumberOfChild + "',@IMG);", myCon);
            myCon.Open();

            selectCommand.Parameters.Add(new MySqlParameter("@IMG", imageBt));

            myReader = selectCommand.ExecuteReader();
        }catch(Exception ex) { }
        }
        public void FindEmployee(Employee em)
        {

            try
            {
                selectCommand = new MySqlCommand("select id,department,designation,telephone,email,Address,mobile,numberchild from aurora.Employee where id='" + em.Id + "';", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

                while (myReader.Read())
                {
                    em.Department = myReader.GetString("department");
                    em.Designation = myReader.GetString("designation");
                    em.Telephone = myReader.GetString("telephone");
                    em.Email = myReader.GetString("email");
                    em.Address = myReader.GetString("address");
                    em.Mobile = myReader.GetString("mobile");
                    em.NumberOfChild = myReader.GetString("numberchild");
                }
            }
            catch (Exception ex) { }


        }

        public void FindM(Manager man)
        {

            try
            {
                selectCommand = new MySqlCommand("select id,department,designation,telephone,email,Address,mobile,numberchild from aurora.Manager where id='" + man.Id + "' ;", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

                while (myReader.Read())
                {
                    man.Department = myReader.GetString("department");
                    man.Designation = myReader.GetString("designation");
                    man.Telephone = myReader.GetString("telephone");
                    man.Email = myReader.GetString("email");
                    man.Address = myReader.GetString("address");
                    man.Mobile = myReader.GetString("mobile");
                    man.NumberOfChild = myReader.GetString("numberchild");
                }
            }
            catch (Exception ex) { }


        }

        public void FindManager(Manager man)
        {

            try
            {
                selectCommand = new MySqlCommand("select id,department,designation,telephone,email,Address,mobile,numberchild from aurora.Manager where id='" + man.Id + "' and designation='"+man.Designation+"';", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

                while (myReader.Read())
                {
                    man.Department = myReader.GetString("department");
                    man.Designation = myReader.GetString("designation");
                    man.Telephone = myReader.GetString("telephone");
                    man.Email = myReader.GetString("email");
                    man.Address = myReader.GetString("address");
                    man.Mobile = myReader.GetString("mobile");
                    man.NumberOfChild = myReader.GetString("numberchild");
                }
            }
            catch (Exception ex) { }


        }
        public void RemoveEmployee(Employee em)
        {
            try
            {
                selectCommand = new MySqlCommand("delete  from aurora.Employee where id='" + em.Id + "';", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

            }
            catch (Exception ex) { }

        }
        public void RemoveManager(Manager man)
        {
            try
            {
                selectCommand = new MySqlCommand("delete  from aurora.Manager where id='" + man.Id + "';", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

            }
            catch (Exception ex) { }

        }
        public void UpdateEmployee(Employee em)
        {
            try
            {
                selectCommand = new MySqlCommand("update   aurora.Employee  set  department='" + em.Department + "',designation='" + em.Designation + "',telephone='" + em.Telephone + "',email='" + em.Email + "',Address='" + em.Address + "',mobile='" + em.Mobile + "',numberchild='" + em.NumberOfChild + "' where id='" + em.Id + "'; ", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

            }
            catch (Exception ex) { }









        }
        public void UpdateManager(Manager man)
        {
            try
            {
                selectCommand = new MySqlCommand("update   aurora.Manager  set  department='" + man.Department + "',designation='" + man.Designation + "',telephone='" + man.Telephone + "',email='" + man.Email + "',Address='" + man.Address + "',mobile='" + man.Mobile + "',numberchild='" + man.NumberOfChild + "' where id='" + man.Id + "'; ", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

            }
            catch (Exception ex) { }


        }

        public void UpdateLeaveCounts(Leave le,Employee emp) {
            try
            {
                selectCommand = new MySqlCommand("update   aurora.leavecounts  set  sickLeaves = '" + le.SickCount + "', withoutpay = '" + le.NoPayCount + "', casual = '" + le.CasualCount + "', pregnant = '" + le.PergnancyCount + "', earned = '" + le.ErenedCount + "', encashmentAble='"+le.enablingEn+"',enablings = '" + le.enablingS + "', enablingCas = '" + le.enablingCas + "', enablingp = '" + le.enablingP+ "', enablingEarned = '" + le.enablingE+ "', enablingNP = '" + le.enablingNP+ "' where department = '" + emp.Department + "' and post = '" + emp.Designation + "'; ", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

            }
            catch (Exception ex) { }





        }


        public void FindEmployeeCounts(Employee em,Leave le)
        {

            try
            {
                selectCommand = new MySqlCommand("select * from aurora.leavecounts where department='" + em.Department + "' and post='" + em.Designation + "';", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

                while (myReader.Read())
                {
                    em.Department = myReader.GetString("department");
                    em.Designation = myReader.GetString("post");
                    le.SickCount = myReader.GetInt16("sickLeaves");
                    le.NoPayCount = myReader.GetInt16("withoutpay");
                    le.CasualCount = myReader.GetInt16("casual");
                    le.PergnancyCount = myReader.GetInt16("pregnant");
                    le.ErenedCount = myReader.GetInt16("earned");
                    le.enablingEn = myReader.GetInt16("encashmentAble");
                    le.enablingS = myReader.GetInt16("enablings");
                    le.enablingCas= myReader.GetInt16("enablingcas");
                    le.enablingP= myReader.GetInt16("enablingp");
                    le.enablingE=myReader.GetInt16("enablingearned");
                    le.enablingNP=myReader.GetInt16("enablingnp");
                }
            }
            catch (Exception ex) { }


        }

        public void FindManagerCounts(Manager em, Leave le)
        {

            try
            {
                selectCommand = new MySqlCommand("select * from aurora.leavecounts where department='" + em.Department + "' and post='" + em.Designation + "';", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

                while (myReader.Read())
                {
                    em.Department = myReader.GetString("department");
                    em.Designation = myReader.GetString("post");
                    le.SickCount = myReader.GetInt16("sickLeaves");
                    le.NoPayCount = myReader.GetInt16("withoutpay");
                    le.CasualCount = myReader.GetInt16("casual");
                    le.PergnancyCount = myReader.GetInt16("pregnant");
                    le.ErenedCount = myReader.GetInt16("earned");
                    le.enablingEn = myReader.GetInt16("encashmentAble");
                    le.enablingS = myReader.GetInt16("enablings");
                    le.enablingCas = myReader.GetInt16("enablingcas");
                    le.enablingP = myReader.GetInt16("enablingp");
                    le.enablingE = myReader.GetInt16("enablingearned");
                    le.enablingNP = myReader.GetInt16("enablingnp");
                }
            }
            catch (Exception ex) { }


        }


        public void AskForLeave(LeaveDetails ld,Employee em) {
            try
            {

                selectCommand = new MySqlCommand("insert into Aurora.leavedescription(leaveid,type,description,fromd,tod,employeeid,accept,tempdif)values('" + null+ "','" +ld.type+ "','" + ld.Description+ "','" + ld.startdate+ "','" + ld.enddate+ "','" + em.Id + "','" + 0+ "','"+ld.tempd+"');", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();
            }
            catch (Exception ex) { }




        }
        public void AskForLeaveM(LeaveDetails ld, Manager m)
        {
            try
            {

                selectCommand = new MySqlCommand("insert into Aurora.leavedescription(leaveid,type,description,fromd,tod,employeeid,accept,tempdif)values('" + null + "','" + ld.type + "','" + ld.Description + "','" + ld.startdate + "','" + ld.enddate + "','" + m.Id + "','" + 0 + "','" + ld.tempd + "');", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();
            }
            catch (Exception ex) { }




        }


        public void AcceptLeave(string x,LeaveDetails ld) {
            try
            {
                selectCommand = new MySqlCommand("select * from aurora.leavedescription where  employeeid="+x+" order by leaveid desc Limit 1; ", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

                while (myReader.Read())
                {
                    ld.type=  myReader.GetString("type");
                    ld.Description=myReader.GetString("description");
                    ld.startdate=myReader.GetString("fromd");
                    ld.enddate=myReader.GetString("tod");
                    ld.accept = myReader.GetString("accept");

                }
            }
            catch (Exception ex) { }






        }

        public void checkAvailability(Employee em)
        {
            try
            {
                selectCommand = new MySqlCommand("select * from aurora.Employee where  id=" + em.Id + " ; ", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

                while (myReader.Read())
                {
                    em.Gender = myReader.GetString("gender");
                    em.sickC = myReader.GetInt16("sickC");
                    em.CasualC = myReader.GetInt16("casualC");
                    em.pregnantC = myReader.GetInt16("pregnantC");
                    em.WithoutC = myReader.GetInt16("withoutC");
                    if (em.sickC == 0 && em.CasualC == 0 && em.pregnantC == 0 && em.WithoutC == 0)
                    {

                        flowere = 1;

                    }
                }
            }
            catch (Exception ex) { }
            myCon.Close();
        }
        public static int flower;
        public static int flowere;
        public void checkAvailabilityM(Manager m)
        {
            try
            {
                selectCommand = new MySqlCommand("select * from aurora.Manager where  id=" + m.Id + " ; ", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

                while (myReader.Read())
                {
                    m.Gender = myReader.GetString("gender");
                    m.sickC = myReader.GetInt16("sickC");
                    m.CasualC = myReader.GetInt16("casualC");
                    m.pregnantC = myReader.GetInt16("pregnantC");
                    m.WithoutC = myReader.GetInt16("withoutC");
                    if (m.sickC == 0 && m.CasualC == 0 && m.pregnantC == 0 && m.WithoutC == 0) {

                        flower = 1;

                    }
                }
            }
            catch (Exception ex) { }
            myCon.Close();
        }

        public void GetPregnantT(Employee em)
        {
            string type = "Pregnant Leave";
            try
            {
                selectCommand = new MySqlCommand("select tempDif from aurora.leavedescription  where  employeeid=" + em.Id + " and type='"+type+"'; ", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

                while (myReader.Read())
                {
                    em.TpregnantC = myReader.GetInt16("tempDif");
                                    }
                           }
            catch (Exception ex) { }
            myCon.Close();
        }
        public void GetSickT(Employee em)
        {
            try
            {
                selectCommand = new MySqlCommand("select tempDif from aurora.leavedescription  where  employeeid=" + em.Id + "and type='Sick' ; ", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

                while (myReader.Read())
                {
                    em.TsickC = myReader.GetInt16("tempDif");
                }
            }
            catch (Exception ex) { }

        }
        public void GetCasualT(Employee em)
        {
            try
            {
                selectCommand = new MySqlCommand("select tempDif from aurora.leavedescription  where  employeeid=" + em.Id + "and type='casual' ; ", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

                while (myReader.Read())
                {
                    em.TCasualC = myReader.GetInt16("tempDif");
                }
            }
            catch (Exception ex) { }

        }
        public void GetWithoutT(Employee em)
        {
            try
            {
                selectCommand = new MySqlCommand("select tempDif from aurora.leavedescription  where  employeeid=" + em.Id + " and type='casual'; ", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

                while (myReader.Read())
                {
                    em.TWithoutC = myReader.GetInt16("tempDif");
                }
            }
            catch (Exception ex) { }

        }

        public void rejectRequest(LeaveDetails le) {


            try
            {
                selectCommand = new MySqlCommand("DELETE FROM aurora.leavedescription WHERE leaveid="+ le.Leaveid+"; ", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

                while (myReader.Read())
                {
                    
                }
            }
            catch (Exception ex) { }



        }

        public void AcceptRequest(LeaveDetails le)
        {


            try
            {
                selectCommand = new MySqlCommand("update  aurora.leavedescription  set  accept = '" + 1 + "' where leaveid='"+le.Leaveid+"';",myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

                while (myReader.Read())
                {

                }
            }
            catch (Exception ex) { }



        }

        public void takeManagerDepartment(Manager M) {
            try
            {
                selectCommand = new MySqlCommand("select department from aurora.Manager  where  id=" + M.Id + ";", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

                while (myReader.Read())
                {
                    M.Department = myReader.GetString("Department");
                }
            }
            catch (Exception ex) { }




        }
        public void takeManagerDesignation(Manager M)
        {
            try
            {
                selectCommand = new MySqlCommand("select designation,department from aurora.Manager  where  id=" + M.Id + ";", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

                while (myReader.Read())
                {
                    M.Designation = myReader.GetString("Designation");
                    M.Department = myReader.GetString("Department");
                }
            }
            catch (Exception ex) { }


            myCon.Close();

        }
        public int retreiveCount(LeaveDetails le) {

            
                selectCommand = new MySqlCommand("select tempDif from leavedescription where leaveid='"+le.Leaveid+"';", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

                while (myReader.Read())
                {
                    le.tempd = myReader.GetInt16("tempDif");
                    int x = le.tempd;
                    return x;
                }
                return 0;
            

            myCon.Close();




        }
        public void UpdateSickM(int id,int val)
        {
            try
            {
                selectCommand = new MySqlCommand("update   aurora.Manager  set  sickC='"+val+"' where id='" + id + "'; ", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

            }
            catch (Exception ex) { }

        }
        public void UpdateSickE(int id,int val)
        {
            try
            {
                selectCommand = new MySqlCommand("update   aurora.Employee  set   sickC='" + val + "' where id='" + id + "'; ", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

            }
            catch (Exception ex) { }

        }
        public void UpdateWitoutM(int id,int val)
        {
            try
            {
                selectCommand = new MySqlCommand("update   aurora.Manager  set   withoutC='" + val + "' where id='" + id + "'; ", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

            }
            catch (Exception ex) { }

        }
        public void UpdateWitoutE(int id, int val)
        {
            try
            {
                selectCommand = new MySqlCommand("update   aurora.Employee  set   withoutC='" + val + "' where id='" + id + "'; ", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

            }
            catch (Exception ex) { }

        }
        public void UpdatePregnantM(int id, int val)
        {
            try
            {
                selectCommand = new MySqlCommand("update   aurora.Manager  set   pregnantC='" + val + "' where id='" + id + "'; ", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

            }
            catch (Exception ex) { }

        }
        public void UpdatePregnantE(int id, int val)
        {
            try
            {
                selectCommand = new MySqlCommand("update   aurora.Employee  set   pregnantC='" + val + "' where id='" + id + "'; ", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

            }
            catch (Exception ex) { }

        }
        public void UpdateCasualM(int id, int val)
        {
            try
            {
                selectCommand = new MySqlCommand("update   aurora.Manager  set   casualC='" + val + "' where id='" + id + "'; ", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

            }
            catch (Exception ex) { }









        }
        public void UpdateCasualE(int id, int val)
        {
            try
            {
                selectCommand = new MySqlCommand("update   aurora.Employee  set   casualC='" + val + "' where id='" + id + "'; ", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();

            }
            catch (Exception ex) { }

        }

        public void takeGenderE(Employee em) {

            selectCommand = new MySqlCommand("select gender from aurora.Employee where id='"+em.Id+"';", myCon);
            myCon.Open();
            myReader = selectCommand.ExecuteReader();

            while (myReader.Read())
            {
                em.Gender = myReader.GetString("gender");

            }

        }


        public void takeGenderM(Manager man)
        {

            selectCommand = new MySqlCommand("select gender from aurora.Manager where id='" + man.Id + "';", myCon);
            myCon.Open();
            myReader = selectCommand.ExecuteReader();

            while (myReader.Read())
            {
                man.Gender = myReader.GetString("gender");

            }

        }
        public void insertAvailableCounts(Manager man,Leave le) {

            try
            {

                selectCommand = new MySqlCommand("update   aurora.Manager  set  sickC = '" +le.SickCount  + "', casualC = '" +le.CasualCount + "', pregnantC = '" + le.PergnancyCount + "', withoutC = '"+le.NoPayCount +"'where id='"+man.Id+"';", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();
            }
            catch (Exception ex) { }



        }

        public void insertAvailableCountsE(Employee em, Leave le)
        {

            try
            {

                selectCommand = new MySqlCommand("update   aurora.Employee  set  sickC = '" + le.SickCount + "', casualC = '" + le.CasualCount + "', pregnantC = '" + le.PergnancyCount + "', withoutC = '" + le.NoPayCount + "'where id='" + em.Id + "';", myCon);
                myCon.Open();
                myReader = selectCommand.ExecuteReader();
            }
            catch (Exception ex) { }



        }
    }
}
