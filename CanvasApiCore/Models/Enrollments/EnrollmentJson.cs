using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasApiCore.Models.Enrollments
{
    /// <summary>
    /// Регистрация
    /// </summary>
    public class EnrollmentJson : BaseEntityJson
    {
        /// <summary>
        /// ID пользователя
        /// </summary>
        public int? user_id;
        /// <summary>
        /// ID курса
        /// </summary>
        public int? course_id;
        /// <summary>
        /// Роль пользователя
        /// </summary>
        public string type;
        /// <summary>
        /// Время создания регистрации
        /// </summary>
        public DateTime? create_at;
        /// <summary>
        /// Время обновления регистрации
        /// </summary>
        public DateTime? update_at;
        /// <summary>
        /// Уникальный ID связанного пользователя
        /// </summary>
        public int? associated_user_id;
        /// <summary>
        /// Время начала регистрации
        /// </summary>
        public DateTime? start_at;
        /// <summary>
        /// Время конца регистрации
        /// </summary>
        public DateTime? end_at;
        /// <summary>
        /// ID раздела курса
        /// </summary>
        public int? course_section_id;
        /// <summary>
        /// Уникальный ID учетной записи пользователя
        /// </summary>
        public int? root_account_id;
        /// <summary>
        /// Пользователь иммет доступ только к своему разделу курса
        /// </summary>
        public bool? limit_privileges_to_course_section;
        /// <summary>
        /// Состояние регистрации
        /// </summary>
        public string enrollment_state;
        /// <summary>
        /// Роль пользователя
        /// </summary>
        public string role;
        /// <summary>
        /// ID роли пользователя
        /// </summary>
        public int? role_id;
        /// <summary>
        /// Дата последней активности пользователя
        /// </summary>
        public DateTime? last_activity_at;
        /// <summary>
        /// Общее время активности пользователя в секундах 
        /// </summary>
        public long? total_activity_time;
        /// <summary>
        /// Оценки пользователя
        /// </summary>
        public Grade grades;
        /// <summary>
        /// ID учетной записи SIS с которой связана регистрация (подразделение (институт?)) (вкл. только если пользователь имеет право просматривать SIS информацию)
        /// </summary>
        public string sis_account_id;
        /// <summary>
        /// ID курса SIS с которой связана регистрация (вкл. только если пользователь имеет право просматривать SIS информацию)
        /// </summary>
        public string sis_course_id;
        /// <summary>
        /// ID интеграции курса
        /// </summary>
        public string course_integration_id;
        /// <summary>
        /// ID раздела SIS с которой связана регистрация (вкл. только если пользователь имеет право просматривать SIS информацию)
        /// </summary>
        public string sis_section_id;
        /// <summary>
        /// ID интеграции раздела курса
        /// </summary>
        public string section_integration_id;
        /// <summary>
        /// ID пользователя SIS с которой связана регистрация (вкл. только если пользователь имеет право просматривать SIS информацию) (прим. m2010218@edu.misis.ru)
        /// </summary>
        public string sis_user_id;
        /// <summary>
        /// URL на страницу пользователя
        /// </summary>
        public string html_url;
    }

    /// <summary>
    /// 
    /// </summary>
    public class Grade
    {
        /// <summary>
        /// URL на страницу оценок пользователя
        /// </summary>
        public string html_url;
        /// <summary>
        /// Общий процент завершения всех заданий
        /// </summary>
        public double? current_score;
        /// <summary>
        /// Текущая оценка
        /// </summary>
        public double? current_grade;
        /// <summary>
        /// Финальный процент завершения
        /// </summary>
        public double? final_score;
        /// <summary>
        /// Финальная оценка
        /// </summary>
        public double? final_grade;
        /// <summary>
        /// Неопубликованный общий процент завершения всех заданий
        /// </summary>
        public double? unposted_current_score;
        /// <summary>
        /// Неопубликованная текущая оценка
        /// </summary>
        public double? unposted_current_grade;
        /// <summary>
        /// Неопубликованный финальный процент завершения
        /// </summary>
        public double? unposted_final_score;
        /// <summary>
        /// Неопубликованная финальная оценка
        /// </summary>
        public double? unposted_final_grade;
    }
}
