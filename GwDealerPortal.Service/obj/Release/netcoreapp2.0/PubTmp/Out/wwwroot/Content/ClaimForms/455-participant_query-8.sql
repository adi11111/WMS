-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Muhammad Adil
-- Create date: 07 Aug 2017
-- Description:	Get the list of Participant in given time.
-- =============================================
alter PROCEDURE Participant_GetByTime
	-- Add the parameters for the stored procedure here
	@appointmentID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF OBJECT_ID('tempdb..#tmpAppointment') IS NOT NULL 
	BEGIN 
		DROP TABLE #tmpAppointment 
	END
    SELECT TOP 1 * INTO #tmpAppointment FROM Appointments 
	WHERE AppointmentID = @appointmentID AND IsDeleted = 0 ORDER BY AppointmentID DESC
	
	DECLARE @date date = (select AppointmentDate from #tmpAppointment)
	DECLARE @startTime time = (select AppointmentDate from #tmpAppointment)
	DECLARE @endTime time = (select AppointmentDate from #tmpAppointment)
	
	
	SELECT p.* FROM Appointments a
	INNER JOIN Participants p
	ON a.AppointmentID = p.AppointmentID
	WHERE a.IsDeleted = 0
	AND p.IsDeleted = 0
	AND a.AppointmentDate = a.AppointmentDate
	AND a.StartTime >= a.StartTime
	AND a.EndTime <= a.EndTime
	
	
	--SELECT p.* FROM Participants p
	--INNER JOIN 
	--( SELECT TOP 1 * FROM Appointments 
	--WHERE AppointmentID = @appointmentID
	--AND IsDeleted = 0 ORDER BY AppointmentID DESC ) a
	----INNER JOIN Participants p
	--ON a.AppointmentID = p.AppointmentID
	--WHERE a.IsDeleted = 0
	--AND p.IsDeleted = 0
	--AND p.AppointmentDate = a.AppointmentDate
	--AND p.StartTime >= a.StartTime
	--AND p.EndTime <= a.EndTime
END
GO
