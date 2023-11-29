using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.CustomService.AttendenceService
{
    public interface IAttendanceService
    {
        IEnumerable<AttendanceViewModel> GetAllAttendances();
        AttendanceViewModel GetAttendanceById(int attendanceId);
/*        void CreateAttendance(AttendanceInsertViewModel attendanceInsertViewModel);
*/        void ApplyLunchBreak(int id);
        void RemoveLunchBreak(int id);
        void ClockIn(int id);
        void ClockOut(int id);
        double GetProductiveHours(int id);
        double GetActualHours(int id);
        /*void CreateAttendance(int userId);*/

    }
}
