namespace CanvasApiCore.Models
{
    /// <summary>
    /// Доп. параметры для включения в запрос AssignmentGroup 
    /// </summary>
    public enum AssignmentGroupInclude
    {
        /// <summary>
        /// Не известно
        /// </summary>
        NONE,
        /// <summary>
        /// Задания
        /// </summary>
        ASSIGNMENTS,
        /// <summary>
        /// Обсуждение
        /// </summary>
        DISCUSSION_TOPIC,
        /// <summary>
        /// Все даты
        /// </summary>
        ALL_DATES,
        /// <summary>
        /// Видимость группы заданий?
        /// </summary>
        ASSIGNMENT_VISIBILITY,
        /// <summary>
        /// Переопределения
        /// </summary>
        OVERRRIDES,
        /// <summary>
        /// Представления
        /// </summary>
        SUBMISSION
    }

    /// <summary>
    /// Типы для исключения из запроса  
    /// </summary>
    public enum ExcludeAssigmSumbTypes
    {
        /// <summary>
        /// Не известно
        /// </summary>
        NONE,
        /// <summary>
        /// Тест
        /// </summary>
        ONLINE_QUIZ,
        /// <summary>
        /// Обсуждение
        /// </summary>
        DISCUSSION_TOPIC,
        /// <summary>
        /// Вики страница
        /// </summary>
        WIKI_PAGE,
        /// <summary>
        /// Внешние инструменты
        /// </summary>
        EXTERNAL_TOOL
    }
}
