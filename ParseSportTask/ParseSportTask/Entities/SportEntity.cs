using System.Collections.Generic;

namespace ParseSportTask
{
    public class Alias
    {
        public string alias { get; set; }
        public string translation { get; set; }
    }

    public class _1
    {
        public int away { get; set; }
        public int home { get; set; }
    }

    public class _2
    {
        public int away { get; set; }
        public int home { get; set; }
    }

    public class SetScores
    {
        public _1 _1 { get; set; }
        public _2 _2 { get; set; }
    }

    public class SetsScore
    {
        public _1 _1 { get; set; }
        public _2 _2 { get; set; }
    }

    public class YellowCards
    {
        public int home { get; set; }
        public int away { get; set; }
    }

    public class RedCards
    {
        public int home { get; set; }
        public int away { get; set; }
    }

    public class Corners
    {
        public int home { get; set; }
        public int away { get; set; }
    }

    public class Stat
    {
        public string match_time_extended { get; set; }
        public bool stoppage_time { get; set; }
        public bool half_time { get; set; }
        public string status { get; set; }
        public SetsScore sets_score { get; set; }
        public int time { get; set; }
        public string score { get; set; }
        public string sport { get; set; }
        public YellowCards yellow_cards { get; set; }
        public RedCards red_cards { get; set; }
        public Corners corners { get; set; }
        public string regular_time_score { get; set; }
        public string overtime_score { get; set; }
        public string after_penalties_score { get; set; }
    }

    public class Team1
    {
        public int id { get; set; }
        public string title { get; set; }
        public string _image_name { get; set; }
    }

    public class Team2
    {
        public int id { get; set; }
        public string title { get; set; }
        public string _image_name { get; set; }
    }

    public class Match
    {
        public int id { get; set; }
        public int weight { get; set; }
        public string title { get; set; }
        public int begin_at { get; set; }
        public bool in_top { get; set; }
        public int match_time { get; set; }
        public string score { get; set; }
        public SetScores set_scores { get; set; }
        public bool match_in_campaign { get; set; }
        public Stat stat { get; set; }
        public string set_number { get; set; }
        public Team1 team1 { get; set; }
        public Team2 team2 { get; set; }
        public List<object> widgets { get; set; }
    }

    public class Outcome
    {
        public int id { get; set; }
        public int line_id { get; set; }
        public string alias { get; set; }
        public int type_id { get; set; }
        public string odd { get; set; }
        public int status { get; set; }
        public int line_status { get; set; }
        public int group_id { get; set; }
        public string game_segment { get; set; }
        public string type { get; set; }
        public bool active { get; set; }
        public bool closed { get; set; }
        public string title { get; set; }
        public int? odd_id { get; set; }
    }

    public class LineDtoCollection
    {
        public int id { get; set; }
        public int status { get; set; }
        public bool top { get; set; }
        public bool is_outright { get; set; }
        public bool is_cyber { get; set; }
        public bool in_favorites { get; set; }
        public Match match { get; set; }
        public List<Outcome> outcomes { get; set; }
        public int other_outcomes_qty { get; set; }
    }

    public class LineSubcategoryDtoCollection
    {
        public int id { get; set; }
        public string title { get; set; }
        public string title_old { get; set; }
        public string icon_name { get; set; }
        public bool in_favorites { get; set; }
        public List<LineDtoCollection> line_dto_collection { get; set; }
    }

    public class LineSupercategoryDtoCollection
    {
        public int id { get; set; }
        public string title { get; set; }
        public List<LineSubcategoryDtoCollection> line_subcategory_dto_collection { get; set; }
    }

    public class LineCategoryDtoCollection
    {
        public int id { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public List<Alias> aliases { get; set; }
        public List<LineSupercategoryDtoCollection> line_supercategory_dto_collection { get; set; }
    }

    public class LinesHierarchy
    {
        public int type { get; set; }
        public string line_type_title { get; set; }
        public List<LineCategoryDtoCollection> line_category_dto_collection { get; set; }
    }

    public class Translations
    {
        public string stream { get; set; }
        public string top { get; set; }
        public string gotoBets { get; set; }
        public string bettingPaused { get; set; }
        public string noActiveMatches { get; set; }
        public string youCanChooseMatchHere { get; set; }
        public string noOpenedLines { get; set; }
    }

    public class SportEntity
    {
        public List<LinesHierarchy> lines_hierarchy { get; set; }
        public int line_count { get; set; }
        public List<int> line_types { get; set; }
        public string site_section { get; set; }
        public bool is_granted_role_user { get; set; }
        public Translations translations { get; set; }
    }
}