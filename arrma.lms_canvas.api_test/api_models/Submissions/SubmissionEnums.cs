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
        ASSIGNMENT,
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

    /// <summary>
    /// Состояние заключения представления
    /// </summary>
    enum SubmissionEnrollmentState
    {
        /// <summary>
        /// Не известно
        /// </summary>
        NONE,
        /// <summary>
        /// Активно
        /// </summary>
        ACTIVE,
        /// <summary>
        /// Заключено
        /// </summary>
        CONCLUDED
    }

    /// <summary>
    /// Типы сортировки
    /// </summary>
    enum SubmissionOrder
    {
        /// <summary>
        /// Не известно
        /// </summary>
        NONE,
        /// <summary>
        /// По ID
        /// </summary>
        ID,
        /// <summary>
        /// По дате проверки
        /// </summary>
        GRADED_AT
    }

    /// <summary>
    /// Направление сортировки
    /// </summary>
    enum SubmissionOrderDir
    {
        /// <summary>
        /// Не известно
        /// </summary>
        NONE, 
        /// <summary>
        /// По возрастанию
        /// </summary>
        ASCENDING,
        /// <summary>
        /// По убыванию
        /// </summary>
        DESCENDING
    }
}
