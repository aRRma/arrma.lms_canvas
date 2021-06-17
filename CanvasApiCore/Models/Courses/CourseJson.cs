using System;
using System.Collections.Generic;
using CanvasApiCore.Models;

namespace CanvasApiCore.Models
{
    /// <summary>
    /// Курс LMS Canvas
    /// </summary>
    public class CourseJson : BaseEntityJson
    {
        /// <summary>
        /// SIS ID курса
        /// </summary>
        public string sis_course_id;
        /// <summary>
        /// UUID (Universally unique identifier) идентификатор курс 
        /// </summary>
        public string uuid;
        /// <summary>
        /// ID интеграции курса
        /// </summary>
        public string integration_id;
        /// <summary>
        /// ID для импорта SIS
        /// </summary>
        public int? sis_import_id;
        /// <summary>
        /// Шифр курса 
        /// </summary>
        public string course_code;
        /// <summary>
        /// состояние курса
        /// </summary>
        public string workflow_state;
        /// <summary>
        /// ID аккаунта с которым ассоц. курс (ID создателя?)
        /// </summary>
        public int? account_id;
        /// <summary>
        /// Уникальный ID учетной записи пользователя
        /// </summary>
        public int? root_account_id;
        /// <summary>
        /// ID типа регистрации на курс
        /// </summary>
        public int? enrollment_term_id;
        /// <summary>
        /// ID стандарта проверки заданий
        /// </summary>
        public int? grading_standard_id;
        /// <summary>
        /// Дата начала курса
        /// </summary>
        public DateTime? start_at;
        /// <summary>
        /// Дата окончания курса
        /// </summary>
        public DateTime? end_at;
        /// <summary>
        /// Локаль курса
        /// </summary>
        public string locale;
        /// <summary>
        /// Список зачислений, связывающих текущего пользователя с курсом
        /// </summary>
        public CourseEnrollmentJson[] enrollments;
        /// <summary>
        /// Общее число активных и приглашенных студентов на курс
        /// </summary>
        public int? total_students;
        /// <summary>
        /// Ссылка на ICS календарь
        /// </summary>
        public CourseCalendarLinkModel calendar;
        /// <summary>
        /// Страница по умолчанию для курса
        /// </summary>
        public string default_view;
        /// <summary>
        /// Тело учебного плана
        /// </summary>
        public string syllabus_body;
        /// <summary>
        /// Количество представлений требующих оценки
        /// </summary>
        public int? needs_grading_count;
        /// <summary>
        /// Сроки регистрации
        /// </summary>
        public CourseTerm term;
        /// <summary>
        /// Прогресс курса (только для модульных курсов)
        /// </summary>
        public CourseProgress course_progress;
        /// <summary>
        /// Применить вес итоговой оценки задания
        /// </summary>
        public bool? apply_assignment_group_weights;
        /// <summary>
        /// Преподаватели на курсе
        /// </summary>
        public UserDisplayJson[] teachers;
        /// <summary>
        /// Список разрешений пользователя на данный курс
        /// </summary>
        public Dictionary<string, bool?> permissions;
        /// <summary>
        /// Публичный курс
        /// </summary>
        public bool? is_public;
        /// <summary>
        /// Публичный ли курс для авторизованных пользователей
        /// </summary>
        public bool? is_public_to_auth_users;
        /// <summary>
        /// Публичный учебный план курса
        /// </summary>
        public bool? public_syllabus;
        /// <summary>
        /// Публичный ли учебный план курса для авторизованных пользователей
        /// </summary>
        public bool? public_syllabus_to_auth;
        /// <summary>
        /// Публичное описание курса
        /// </summary>
        public string public_description;
        /// <summary>
        /// Лимит загрузки файлов
        /// </summary>
        public int? storage_quota_mb;
        /// <summary>
        /// Использованный лимит загрузки файлов
        /// </summary>
        public int? storage_quota_used_mb;
        /// <summary>
        /// Скрыты итоговые оценки
        /// </summary>
        public bool? hide_final_grades;
        /// <summary>
        /// Тип лицензии крс
        /// </summary>
        public string license;
        /// <summary>
        /// Разрешить студентам редактировать задания
        /// </summary>
        public bool? allow_student_assignment_edits;
        /// <summary>
        /// Разрешить wiki комментария
        /// </summary>
        public bool? allow_wiki_comments;
        /// <summary>
        /// Разрешить студентам прикреплять файлы к обсуждениям
        /// </summary>
        public bool? allow_student_forum_attachments;
        /// <summary>
        /// Открытая регистрация на курс
        /// </summary>
        public bool? open_enrollment;
        /// <summary>
        /// Самостоятельная регистрация на курс
        /// </summary>
        public bool? self_enrollment;
        /// <summary>
        /// Ограничить регистрацию датами курса
        /// </summary>
        public bool? restrict_enrollments_to_course_dates;
        /// <summary>
        /// Формат курса
        /// </summary>
        public string course_format;
        /// <summary>
        /// Доступ к курсу ограничен по дате
        /// </summary>
        public bool? access_restricted_by_date;
        /// <summary>
        /// Временная зона
        /// </summary>
        public string time_zone;
        /// <summary>
        /// Куср создан по шаблону
        /// </summary>
        public bool? blueprint;
        /// <summary>
        /// Ограничения шаблона
        /// </summary>
        public object blueprint_restrictions;
        /// <summary>
        /// Ограничение шаблона по типу обьекта
        /// </summary>
        public object blueprint_restrictions_by_object_type;
    }

    /// <summary>
    /// Календарь курса
    /// </summary>
    public class CourseCalendarLinkModel
    {
        /// <summary>
        /// ICS - (iCalendar) ссылка на календарь
        /// </summary>
        public string ics;
    }

    /// <summary>
    /// Срока обучения
    /// </summary>
    public class CourseTerm : BaseEntityJson
    {
        /// <summary>
        /// Дата начала курса
        /// </summary>
        public DateTime? start_at;
        /// <summary>
        /// Дата конца курса
        /// </summary>
        public DateTime? end_at;
        /// <summary>
        /// Состояние курса
        /// </summary>
        public string workflow_state;
        /// <summary>
        /// ID стандарта оценки курса
        /// </summary>
        public int? grading_period_group_id;
    }

    /// <summary>
    /// Прогресс курса
    /// </summary>
    public class CourseProgress
    {
        /// <summary>
        /// Общее количество требования для всех модулей (заданий?)
        /// </summary>
        public int? requirement_count;
        /// <summary>
        /// Общее количество требований, которые пользователь выполнил из всех модулей (заданий?)
        /// </summary>
        public int? requirement_completed_count;
        /// <summary>
        /// URL след. требования
        /// </summary>
        public string next_requirement_url;
        /// <summary>
        /// Дата завершения курса
        /// </summary>
        public DateTime? completed_at;
    }
}
