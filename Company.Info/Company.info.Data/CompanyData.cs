using Company.info.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.info.Data
{
    public class CompanyData
    {
        public List<TblStudent> GetStudentDetails()
        {
            using (var context = new SchoolDBContext())
            {
                var totalStudent = context.TblStudents.OrderBy(a => a.Fname).ToList();

                return totalStudent;
            }

        }

        public TblStudent GetStudentById(int Id)
        {
            using (var context = new SchoolDBContext())
            {
                TblStudent student = context.TblStudents.FirstOrDefault(a => a.Id == Id);

                return student;
            }

        }

        public int InsertStudent(TblStudent stdata)
        {
            using (var context = new SchoolDBContext())
            {
                context.TblStudents.Add(stdata);
                context.SaveChanges();

                return stdata.Id;
            }
        }
    }
}
