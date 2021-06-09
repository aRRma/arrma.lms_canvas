using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasApiCore.Models.Assignments;
using Newtonsoft.Json;

namespace CanvasApiCore.Models.Assignment_Group
{
    /// <summary>
    /// Группа заданий
    /// </summary>
    public class AssignmentGroup : CanvasEntity
    {
        /// <summary>
        /// Позиция группы заданий
        /// </summary>
        public int? position;
        /// <summary>
        /// Вес группы заданий
        /// </summary>
        public double? group_weight;
        /// <summary>
        /// SIS (School Data Sync) идентификатор источника группы заданий
        /// </summary>
        public string sis_source_id;
        /// <summary>
        /// Информация интеграции (вообще нет в запросе)
        /// </summary>
        public object integration_data;
        /// <summary>
        /// Массив заданий
        /// </summary>
        public Assignment[] assignments;
        /// <summary>
        /// Правила оценки
        /// </summary>
        public GradingRules rules;
    }

    /// <summary>
    /// Правила оценки
    /// </summary>
    public class GradingRules
    {
        /// <summary>
        /// Наименьшее количество баллов которые должны быть отброшены
        /// </summary>
        public int? drop_lowest;
        /// <summary>
        /// Наибольшее количество баллов которые должны быть отброшены
        /// </summary>
        public int? drop_highest;
        /// <summary>
        /// ID заданий которые не должны быть отброшены
        /// </summary>
        public int[] never_drop;
    }
}
