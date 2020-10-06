using SIS.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIS.Models.Repositories
{
    public class MajorRepository
    {
        private List<Major> _majors;

        public MajorRepository()
        {
            // sample data
            _majors = new List<Major>
                {
                    new Major { MajorId=1, MajorName="Art" },
                    new Major { MajorId=2, MajorName="Business" },
                    new Major { MajorId=3, MajorName="Computer Science" }
                };
        }
        public List<Major> GetAllMajors()
        {
            return _majors;
        }
        public Major GetMajor(int majorId)
        {
            return _majors.Where(i => i.MajorId == majorId).FirstOrDefault();
        }
        public Major GetMajor(string majorName)
        {
            return _majors.Where(i => i.MajorName == majorName).FirstOrDefault();
        }
        public Major AddMajor(string majorName)
        {
            var newMajor = new Major()
            {
                MajorId = _majors.Max(m => m.MajorId) + 1,
                MajorName = majorName
            };
            _majors.Add(newMajor);
            return newMajor;
        }
        public Major EditMajor(Major major)
        {
            var editedMajor = _majors.Where(n => n.MajorId == major.MajorId).FirstOrDefault();
            editedMajor.MajorName = major.MajorName;
            return editedMajor;
        }
        public void RemoveMajor(int id)
        {
            var major = _majors.Where(m => m.MajorId == id).FirstOrDefault();
            _majors.Remove(major);
        }
    }
}
