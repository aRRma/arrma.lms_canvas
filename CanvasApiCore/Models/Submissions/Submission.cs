using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasApiCore.Models.Assignments;
using CanvasApiCore.Models.Courses;
using CanvasApiCore.Models.Users;
using Newtonsoft.Json;

namespace CanvasApiCore.Models.Submissions
{
    /// <summary>
    /// Представление задания студента (для запроса с группировкой)
    /// </summary>
    public class GroupedSubmissions
    {
        /// <summary>
        /// ID представления для интеграции
        /// </summary>
        public int? integration_id;
        /// <summary>
        /// ID раздела
        /// </summary>
        public string section_id;
        /// <summary>
        /// ID пользователя SIS с которой связана регистрация (вкл. только если пользователь имеет право просматривать SIS информацию) (прим. m2010218@edu.misis.ru)
        /// </summary>
        public string sis_user_id;
        /// <summary>
        /// Массив сгруппированных представлений заданий
        /// </summary>
        public Submission[] submissions;
        /// <summary>
        /// ID пользователя 
        /// </summary>
        public string user_id;
    }

    /// <summary>
    /// Представление задания
    /// </summary>
    public class Submission : CanvasEntity
    {
        /// <summary>
        /// ID задания
        /// </summary>
        public int? assignment_id;
        /// <summary>
        /// Задание
        /// </summary>
        public Assignment assignment;
        /// <summary>
        /// Прикрепленные файлы
        /// </summary>
        public Attachment.Attachment[] attachments;
        /// <summary>
        /// Дата кеширования
        /// </summary>
        public DateTime? cached_due_date;
        /// <summary>
        /// Курс
        /// </summary>
        public Course course;
        /// <summary>
        /// Количество попыток
        /// </summary>
        public int? attempt;
        /// <summary>
        /// Тело представления (было только в задании типа "тест" "user: 32081, quiz: 33811, score: 5.0, time: 2021-03-23 16:58:06 +0300")
        /// </summary>
        public string body;
        /// <summary>
        /// Оценка за отправку представления
        /// </summary>
        public string grade;
        /// <summary>
        /// False если студент отправил задание после последне проверки
        /// </summary>
        public bool? grade_matches_current_submission;
        /// <summary>
        /// URL на страницу представления
        /// </summary>
        public string html_url;
        /// <summary>
        /// Сссылка на превью представления
        /// </summary>
        public string preview_url;
        /// <summary>
        /// Предварительная оценка
        /// </summary>
        public double? score;
        /// <summary>
        /// Комментарии для представления
        /// </summary>
        public SubmissionComment[] submission_comments;
        /// <summary>
        /// Тип представления задания
        /// </summary>
        public string submission_type;
        /// <summary>
        /// Дата отправки задания
        /// </summary>
        public DateTime? submitted_at;
        /// <summary>
        /// URL отправки материалов
        /// </summary>
        public string url;
        /// <summary>
        /// ID пользователя создавшего представление (студента)
        /// </summary>
        public int? user_id;
        /// <summary>
        /// ID пользователя который проверил представление задания
        /// </summary>
        public int? grader_id;
        /// <summary>
        /// Дата проверки задания
        /// </summary>
        public DateTime? graded_at;
        /// <summary>
        /// Пользователь (студент)
        /// </summary>
        public User user;
        /// <summary>
        /// Отправили представление поздно
        /// </summary>
        public bool? late;
        /// <summary>
        /// Видно ли пользователю задание (если false, то пользователь больше не видит задание и оно не учитывается в его оценке)
        /// </summary>
        public bool? assignment_visible;
        /// <summary>
        /// Задание не учитывается в оценке пользователя
        /// </summary>
        public bool? excused;
        /// <summary>
        /// Задание отсутствует
        /// </summary>
        public bool? missing;
        /// <summary>
        /// Политика поздней сдачи задания
        /// </summary>
        public string late_policy_status;
        /// <summary>
        /// Сумма балов вычитаемая если представление было загружено поздно
        /// </summary>
        public long? points_deducted;
        /// <summary>
        /// Время в секундах на которое просрочили
        /// </summary>
        public long? seconds_late;
        /// <summary>
        /// Состояние оценки представления (оценено или нет)
        /// </summary>
        public string workflow_state;
        /// <summary>
        /// Список истории представлений
        /// </summary>
        public SubmissionHistory[] submission_history;
    }

    /// <summary>
    /// Представление из истории
    /// </summary>
    public class SubmissionHistory : CanvasEntity
    {
        /// <summary>
        /// Тело представления (было только в задании типа "тест" "user: 32081, quiz: 33811, score: 5.0, time: 2021-03-23 16:58:06 +0300")
        /// </summary>
        public string body;
        /// <summary>
        /// URL отправки материалов
        /// </summary>
        public string url;
        /// <summary>
        /// Оценка за отправку представления
        /// </summary>
        public string grade;
        /// <summary>
        /// Предварительная оценка
        /// </summary>
        public double? score;
        /// <summary>
        /// Дата отправки задания
        /// </summary>
        public DateTime? submitted_at;
        /// <summary>
        /// ID задания
        /// </summary>
        public int? assignment_id;
        /// <summary>
        /// ID пользователя создавшего представление (студента)
        /// </summary>
        public int? user_id;
        /// <summary>
        /// Тип представления задания
        /// </summary>
        public string submission_type;
        /// <summary>
        /// Состояние оценки представления (оценено или нет)
        /// </summary>
        public string workflow_state;
        /// <summary>
        /// False если студент отправил задание после последне проверки
        /// </summary>
        public bool? grade_matches_current_submission;
        /// <summary>
        /// Дата проверки задания
        /// </summary>
        public DateTime? graded_at;
        /// <summary>
        /// ID пользователя который проверил представление задания
        /// </summary>
        public int? grader_id;
        /// <summary>
        /// Количество попыток
        /// </summary>
        public int? attempt;
        /// <summary>
        /// Дата кеширования
        /// </summary>
        public DateTime? cached_due_date;
        /// <summary>
        /// Задание не учитывается в оценке пользователя
        /// </summary>
        public bool? excused;
        /// <summary>
        /// Политика поздней сдачи задания
        /// </summary>
        public string late_policy_status;
        /// <summary>
        /// Сумма балов вычитаемая если представление было загружено поздно
        /// </summary>
        public long? points_deducted;
        /// <summary>
        /// Отправили представление поздно
        /// </summary>
        public bool? late;
        /// <summary>
        /// Задание отсутствует
        /// </summary>
        public bool? missing;
        /// <summary>
        /// Время в секундах на которое просрочили
        /// </summary>
        public long? seconds_late;
        /// <summary>
        /// Сссылка на превью представления
        /// </summary>
        public string preview_url;
        /// <summary>
        /// Прикрепленные файлы
        /// </summary>
        public Attachment.Attachment[] attachments;
    }

    /// <summary>
    /// Комментарий представления
    /// </summary>
    public class SubmissionComment : CanvasEntity
    {
        /// <summary>
        /// Автор комментария
        /// </summary>
        public UserDisplay author;
        /// <summary>
        /// ID автора комментария
        /// </summary>
        public int? author_id;
        /// <summary>
        /// Имя автора
        /// </summary>
        public string author_name;
        /// <summary>
        /// Путь до аватарки автора
        /// </summary>
        public string avatar_path;
        /// <summary>
        /// Комментарий
        /// </summary>
        public string comment;
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime? created_at;
        /// <summary>
        /// Дата изменения
        /// </summary>
        public DateTime? edited_at;
        /// <summary>
        /// Медиа контент комментария
        /// </summary>
        public MediaComment media_comment;
    }

    /// <summary>
    /// Медиа контент комментария
    /// </summary>
    public class MediaComment
    {
        /// <summary>
        /// Тип медиа контента комментария
        /// </summary>
        [JsonProperty(PropertyName = "content-type")]
        public string content_type { get; private set; }
        /// <summary>
        /// Отображаемое имя
        /// </summary>
        public string display_name;
        /// <summary>
        /// ID медиа
        /// </summary>
        public string media_id;
        /// <summary>
        /// Тип медиа
        /// </summary>
        public string media_type;
        /// <summary>
        /// URL ссылка на медиа
        /// </summary>
        public string url;
    }
}
