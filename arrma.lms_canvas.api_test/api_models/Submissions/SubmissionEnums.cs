namespace arrma.lms_canvas.api_test.api_models.Submissions
{
    /// <summary>
    /// Доп. параметры для включения в запрос Submission
    /// </summary>
    enum SubmissionInclude
    {
        /// <summary>
        /// Неизвестно
        /// </summary>
        NONE,
        /// <summary>
        /// История представления
        /// </summary>
        SUBMISSION_HISTORY,
        /// <summary>
        /// Комментарии представления
        /// </summary>
        SUBMISSION_COMMENTS,
        /// <summary>
        /// Рубрики заданий
        /// </summary>
        RUBRIC_ASSESSMENT,
        /// <summary>
        /// Задания
        /// </summary>
        ASSIGNMENTS,
        /// <summary>
        /// Общая оценка
        /// </summary>
        TOTAL_SCORES,
        /// <summary>
        /// Видимость
        /// </summary>
        VISIBILITY,
        /// <summary>
        /// Курс
        /// </summary>
        COURSE,
        /// <summary>
        /// Пользователь
        /// </summary>
        USER
    }

    /// <summary>
    /// Тип представления задания
    /// </summary>
    enum SubmissionType
    {
        /// <summary>
        /// Неизвестно
        /// </summary>
        NONE,
        /// <summary>
        /// Онлайн тест
        /// </summary>
        ONLINE_QUIZ,
        /// <summary>
        /// На бумаге ?:)
        /// </summary>
        ON_PAPER,
        /// <summary>
        /// Обсуждение
        /// </summary>
        DISCUSSION_TOPIC,
        /// <summary>
        /// Внешний инструмент
        /// </summary>
        EXTERNAL_TOOL,
        /// <summary>
        /// Онлайн загрузка
        /// </summary>
        ONLINE_UPLOAD,
        /// <summary>
        /// ввод текста онлайн
        /// </summary>
        ONLINE_TEXT_ENTRY,
        /// <summary>
        /// онлайн ссылка
        /// </summary>
        ONLINE_URL,
        /// <summary>
        /// Примечания студентов
        /// </summary>
        STUDENT_ANNOTATION
    }

    /// <summary>
    /// Состояние проверки задания
    /// </summary>
    enum SubmissionWorkflowState
    {
        /// <summary>
        /// Неизвестно
        /// </summary>
        NONE,
        /// <summary>
        /// Отправлено
        /// </summary>
        SUBMITTED,
        /// <summary>
        /// Не отправлено
        /// </summary>
        UNSUBMITTED,
        /// <summary>
        /// Проверено
        /// </summary>
        GRADED,
        /// <summary>
        /// Ожидает оценки
        /// </summary>
        PENDING_REVIEW
    }

    /// <summary>
    /// Состояние оценки задания
    /// </summary>
    enum SubmissionGrade
    {
        /// <summary>
        /// Неизвестно (не проверено или по уважительной причине)
        /// </summary>
        NONE,
        /// <summary>
        /// Завершено
        /// </summary>
        COMPLETE,
        /// <summary>
        /// Не  завешено
        /// </summary>
        INCOMPLETE
    }
}
