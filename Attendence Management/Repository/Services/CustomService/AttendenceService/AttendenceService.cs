using Domain.Models;
using Domain.ViewModels;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.CustomService.AttendenceService
{
    public class AttendanceService : IAttendanceService
    {
        private readonly MainDbcontext _dbContext;

        public AttendanceService(MainDbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<AttendanceViewModel> GetAllAttendances() =>
            _dbContext.Attendances.ToList().Select(MapToViewModel);

        public AttendanceViewModel GetAttendanceById(int attendanceId) =>
            MapToViewModel(_dbContext.Attendances.FirstOrDefault(a => a.AttendanceID == attendanceId));

        public void ClockIn(int userId)
        {
            // Check if there is an open attendance for the user
            var openAttendance = _dbContext.Attendances
                .FirstOrDefault(a => a.UserID == userId && a.ClockOutDateTime == null);

            if (openAttendance == null)
            {
                // If no open attendance, create a new one
                var attendance = new Attendance
                {
                    UserID = userId,
                    ClockInDateTime = DateTime.Now,
                    ClockOutDateTime = DateTime.MinValue, // Set to initial value
                    LunchBreakStart = DateTime.MinValue, // Set to initial value
                    LunchBreakEnd = DateTime.MinValue // Set to initial value
                };

                _dbContext.Attendances.Add(attendance);
                _dbContext.SaveChanges();
            }
        }



        public void ApplyLunchBreak(int attendanceId) =>
            UpdateAttendanceDateTime(attendanceId, (a, v) => a.LunchBreakStart = v, DateTime.Now);

        public void RemoveLunchBreak(int attendanceId) =>
            UpdateAttendanceDateTime(attendanceId, (a, v) => a.LunchBreakEnd = v, DateTime.Now);

        public void ClockOut(int attendanceId)
        {
            UpdateAttendanceDateTime(attendanceId, (a, v) => a.ClockOutDateTime = v, DateTime.Now);

            var attendance = _dbContext.Attendances.Find(attendanceId);
            if (attendance?.ClockOutDateTime != null)
            {
                CalculateProductiveHours(attendance);
                CalculateAndUpdateActualHours(attendance);
            }
        }



        public double GetProductiveHours(int attendanceId)
        {
            var attendance = _dbContext.Attendances.Find(attendanceId);

            if (attendance != null && attendance.ClockOutDateTime != null)
            {
                return CalculateProductiveHours(attendance);
            }

            return 0;
        }

        public double GetActualHours(int attendanceId)
        {
            var attendance = _dbContext.Attendances.Find(attendanceId);

            return attendance?.ActualHours ?? 0;
        }

        private double CalculateProductiveHours(Attendance attendance)
        {
            DateTime clockOut = attendance.ClockOutDateTime;
            DateTime lunchBreakStart = attendance.LunchBreakStart;
            DateTime lunchBreakEnd = attendance.LunchBreakEnd;

            // Check for null values
            if (clockOut != DateTime.MinValue && lunchBreakStart != DateTime.MinValue && lunchBreakEnd != DateTime.MinValue)
            {
                TimeSpan lunchBreakDuration = lunchBreakEnd - lunchBreakStart;
                return (clockOut - attendance.ClockInDateTime - lunchBreakDuration).TotalHours;
            }

            return 0;
        }
        private void CalculateAndUpdateActualHours(Attendance attendance)
        {
            DateTime clockOut = attendance.ClockOutDateTime;
            double actualHours = (clockOut - attendance.ClockInDateTime).TotalHours;

            // Update the ActualHours property
            attendance.ActualHours = actualHours;
            _dbContext.SaveChanges();
        }
        private void UpdateAttendanceDateTime(int attendanceId, Action<Attendance, DateTime> updateAction, DateTime value)
        {
            var attendance = _dbContext.Attendances.Find(attendanceId);

            if (attendance != null)
            {
                // Execute the update action
                updateAction(attendance, value);
                _dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Attendance with ID {attendanceId} not found.");
                // Handle the case where attendance is not found (null)
                // You might want to log this or throw an exception depending on your application's logic.
            }
        }


       



        private static AttendanceViewModel MapToViewModel(Attendance attendance) =>
            new AttendanceViewModel
            {
                AttendanceID = attendance.AttendanceID,
                UserID = attendance.UserID,
                ClockInDateTime = attendance.ClockInDateTime,
                ClockOutDateTime = attendance.ClockOutDateTime,
                LunchBreakStart = attendance.LunchBreakStart,
                LunchBreakEnd = attendance.LunchBreakEnd,
                ActualHours = attendance.ActualHours,
                ProductiveHours = attendance.ProductiveHours
            };
    }

}
