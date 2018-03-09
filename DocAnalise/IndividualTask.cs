using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocAnalise
{
    class IndividualTask
    {
        public struct Marker
        {
            public string typeOfPractice;
            public string institute;
            public string specialty;
            public string department;
            public string StudentFIO;
            public string step;
            public string group;
                //public string frstDate
                //public string lastDate
                //public string TeacherFIO
                //public string Position
                //public string AcademicTitle
                //public string firstTask
                //public string secondTask, thirdTask, fourthTask, fifthTask",
                //"FD1", "FD2", "FD3", "FD4", "FD5", "LD1", "LD2", "LD3", "LD4", "LD5", "GenFIO"
        }

       

        IndividualTask(string dep; )
        {
            Marker marker = new Marker();
            marker.department = dep;
        }
    }
}
