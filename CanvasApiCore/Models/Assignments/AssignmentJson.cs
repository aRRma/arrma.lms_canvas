using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasApiCore.Models;

namespace CanvasApiCore.Models
{
    /// <summary>
    /// Задание
    /// </summary>
    public class AssignmentJson : BaseEntityJson
    {
        /// <summary>
        /// Описание задания в виде HTML страницы
        /// </summary>
        public string description;
        /// <summary>
        /// Дата создания задания
        /// </summary>
        public DateTime? created_at;
        /// <summary>
        /// Дата обновления задания
        /// </summary>
        public DateTime? updated_at;
        /// <summary>
        /// Срок выполнения (null если его нет)
        /// </summary>
        public DateTime? due_at;
        /// <summary>
        /// Дата блокировки
        /// </summary>
        public DateTime? lock_at;
        /// <summary>
        /// Дата разблокировки
        /// </summary>
        public DateTime? unlock_at;
        /// <summary>
        /// Задание переопределенное
        /// </summary>
        public bool? has_overrides;
        /// <summary>
        /// Массив сроков заданий для всех разделов
        /// </summary>
        public AssignmentDate[] all_dates;
        /// <summary>
        /// ID курса
        /// </summary>
        public int? course_id;
        /// <summary>
        /// Ссылка на страницу задания
        /// </summary>
        public string html_url;
        /// <summary>
        /// Ссылка на загрузку представления задания
        /// </summary>
        public string submissions_download_url;
        /// <summary>
        /// ID группы заданий
        /// </summary>
        public int? assignment_group_id;
        /// <summary>
        /// Требуется ли назначения срока выполнения задания
        /// </summary>
        public bool? due_date_required;
        /// <summary>
        /// Массив расширений файлов (для типов задания "online_upload")
        /// </summary>
        public string[] allowed_extensions; //форматы файлов для загрузки
        /// <summary>
        /// Максимальная длина названия задания
        /// </summary>
        public int? max_name_length;
        /// <summary>
        /// Это групповое задание (влияет на оценку группы или индивидуально каждого студента)
        /// </summary>
        public bool? grade_group_students_individually;
        /// <summary>
        /// Требуются ли эксперты для оценки задания
        /// </summary>
        public bool? peer_reviews;
        /// <summary>
        /// Экспертная оценка назначена автоматически
        /// </summary>
        public bool? automatic_peer_reviews;
        /// <summary>
        /// Можно ли экспертам оценивать другие группы
        /// </summary>
        public bool? intra_group_peer_reviews;
        /// <summary>
        /// ID группового набора заданий
        /// </summary>
        public int? group_category_id;
        /// <summary>
        /// Количество заданий требующих оценки
        /// </summary>
        public int? needs_grading_count;
        /// <summary>
        /// Позиция задания
        /// </summary>
        public int? position;
        /// <summary>
        /// Размещено для SIS 
        /// </summary>
        public bool? post_to_sis;
        /// <summary>
        /// ID задания для интеграции
        /// </summary>
        public int? integration_id;
        /// <summary>
        /// Информация для интеграции задания
        /// </summary>
        public object integration_data;
        /// <summary>
        /// Скрыто
        /// </summary>
        public bool? muted;
        /// <summary>
        /// Максимальное количество баллов за задание
        /// </summary>
        public double? points_possible;
        /// <summary>
        /// Массив типов представления заданий
        /// </summary>
        public string[] submission_types;
        /// <summary>
        /// Была хоть одна отправка задания
        /// </summary>
        public bool? has_submitted_submissions;
        /// <summary>
        /// Стандарт оценки задания
        /// </summary>
        public string grading_type;
        /// <summary>
        /// ID стандарта оценки задания
        /// </summary>
        public int? grading_standard_id;
        /// <summary>
        /// Опубликовано
        /// </summary>
        public bool? published;
        /// <summary>
        /// Не опубликовано
        /// </summary>
        public bool? unpublishable;
        /// <summary>
        /// Отображается только для переопределенных
        /// </summary>
        public bool? only_visible_to_overrides;
        /// <summary>
        /// Независимо заблокировано ли для пользователя
        /// </summary>
        public bool? locked_for_user;
        /// <summary>
        /// Представление задания для пользователя
        /// </summary>
        public SubmissionJson submission;
        /// <summary>
        /// Массив id пользователей которые видят задание
        /// </summary>
        public string[] assignment_visibility;
        /// <summary>
        /// Массив переопределений заданий
        /// </summary>
        public AssignmentOverride[] overrides;
        /// <summary>
        /// исключить задание из итоговой оценки пользователя
        /// </summary>
        public bool? omit_from_final_grade;
        /// <summary>
        /// Анонимная оценка экспертами
        /// </summary>
        public bool? anonymous_peer_reviews;
        /// <summary>
        /// Модерация проверки заданий
        /// </summary>
        public bool? moderated_grading;
        /// <summary>
        /// Анонимные нотации инструкторов
        /// </summary>
        public bool? anonymous_instructor_annotations;
        /// <summary>
        /// Параметры безопасности
        /// </summary>
        public string secure_params;
        /// <summary>
        /// Закрыт период оценки задания
        /// </summary>
        public bool? in_closed_grading_period;
        /// <summary>
        /// Задание тест
        /// </summary>
        public bool? is_quiz_assignment;
    }

    /// <summary>
    /// Даты задания
    /// </summary>
    public class AssignmentDate
    {
        /// <summary>
        /// ID переопределения задания, которое представляет это задание
        /// </summary>
        public int? id;
        /// <summary>
        /// Представляю ли эти даты базовое задание
        /// </summary>
        public bool? @base;
        /// <summary>
        /// Название раздела
        /// </summary>
        public string title;
        /// <summary>
        /// Срок выполнения
        /// </summary>
        public DateTime? due_at;
        /// <summary>
        /// Дата разблокировки
        /// </summary>
        public DateTime? unlock_at;
        /// <summary>
        /// Дата блокировки
        /// </summary>
        public DateTime? lock_at;
    }

    /// <summary>
    /// Переопределение задания
    /// </summary>
    public class AssignmentOverride
    {
        /// <summary>
        /// ID переопределения задания
        /// </summary>
        public int? id;
        /// <summary>
        /// ID задания
        /// </summary>
        public int? assignment_id;
        /// <summary>
        /// Массив ID студентов
        /// </summary>
        public int[] student_ids;
        /// <summary>
        /// ID целевой группы переопределения задания
        /// </summary>
        public int? group_id;
        /// <summary>
        /// ID раздела курса
        /// </summary>
        public int? course_section_id;
        /// <summary>
        /// Название
        /// </summary>
        public string title;
        /// <summary>
        /// Срок выполнения
        /// </summary>
        public DateTime? due_at;
        /// <summary>
        /// Все дни
        /// </summary>
        public int? all_day;
        /// <summary>
        /// Дата всех дней
        /// </summary>
        public DateTime? all_day_date;
        /// <summary>
        /// Дата разблокировки
        /// </summary>
        public DateTime? unlock_at;
        /// <summary>
        /// Дата блокировки
        /// </summary>
        public DateTime? lock_at;
    }
}