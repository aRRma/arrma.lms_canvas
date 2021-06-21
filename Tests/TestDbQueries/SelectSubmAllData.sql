SELECT c.Course_code, s.Name, s.Surname, s.Login_id, s.Role, a.Name, a.Submission_types, a.Allowed_extensions, Submissions.Workflow_state, Submissions.Score, Submissions.Grade, Submissions.Attempt, t.name, t.surname, t.role, Submissions.Graded_at 
FROM Submissions
JOIN Assignments a ON a.id = Submissions.AssignmentId
    JOIN AssignmentGroups ag on a.AssignmentGroupId = ag.Id
        JOIN Courses c ON AG.CourseId = c.Id
JOIN Teachers t ON t.id = Submissions.GraderId
JOIN Students s ON s.id = Submissions.StudentId
WHERE Submissions.Workflow_state = "graded" AND Graded_at >= "2021-01-01"
ORDER BY Graded_at DESC