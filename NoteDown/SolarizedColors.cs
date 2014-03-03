using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NoteDown
{
    internal static class SolarizedColors
    {
        public static Color BackGroundColor = GetColor("#002b36");
        public static Color ForeColor = GetColor("#839496");
        public static Color LightBackGroundColor = GetColor("#fdf6e3");
        public static Color LightForeColor = GetColor("#657b83");
        private static Color yellow = GetColor("#b58900");
        private static Color orange = GetColor("#cb4b16");
        private static Color red = GetColor("#dc322f");
        private static Color magenta = GetColor("#d33682");
        private static Color violet = GetColor("#6c71c4");
        private static Color blue = GetColor("#268bd2");
        private static Color cyan = GetColor("#2aa198");
        private static Color green = GetColor("#859900");

        private static Color GetColor(string s)
        {
            ColorConverter cv = new ColorConverter();
            return (Color)cv.ConvertFromString(s);
        }

        public static Color GetHightightColor(string s, bool isCodeBlock)
        {
            if (string.IsNullOrEmpty(s)) return SolarizedColors.ForeColor;
            if (isCodeBlock)
            {
                if (Markup.IsNumber(s)) return SolarizedColors.blue;

                char[] split = new char[] { ' ', '\'', ',', '+' };
                List<string> CsKeyWordList = CsKeyWord.Split(split, StringSplitOptions.RemoveEmptyEntries).ToList();
                List<string> SqlKeyWordList = SqlKeyWord.ToUpper().Split(split, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (CsKeyWordList.Contains(s)) return SolarizedColors.green;
                else if (SqlKeyWordList.Contains(s)) return SolarizedColors.magenta;
                else return SolarizedColors.ForeColor;
            }
            else return GetHightightColorByTag(s);
        }

        private static Color GetHightightColorByTag(string s)
        {
            MarkdownTag tag = Markup.GetStyle(s);
            switch (tag)
            {
                case MarkdownTag.FirstHeader:
                    return SolarizedColors.yellow;

                case MarkdownTag.SecondHeader:
                    return SolarizedColors.orange;

                case MarkdownTag.Bold:
                    return SolarizedColors.violet;

                case MarkdownTag.Italic:
                    return SolarizedColors.red;

                case MarkdownTag.PlainText:
                    return SolarizedColors.cyan;

                default:
                    return SolarizedColors.ForeColor;
            }
        }

        //https://github.com/isagalaev/highlight.js/blob/master/src/languages/cs.js
        private static string CsKeyWord = @"
            'abstract as base bool break byte case catch char checked const continue decimal ' +
            'default delegate do double else enum event explicit extern false finally fixed float ' +
            'for foreach goto if implicit in int interface internal is lock long new null ' +
            'object operator out override params private protected public readonly ref return sbyte ' +
            'sealed short sizeof stackalloc static string struct switch this throw true try typeof ' +
            'uint ulong unchecked unsafe ushort using virtual volatile void while async await ' +
            'ascending descending from get group into join let orderby partial select set value var ' +
            'where yield'
            ";

        //https://github.com/isagalaev/highlight.js/blob/master/src/languages/sql.js
        private static string SqlKeyWord = @"
            'begin end start commit rollback savepoint lock alter create drop rename call '+
            'delete do handler insert load replace select truncate update set show pragma grant '+
            'merge describe use explain help declare prepare execute deallocate savepoint release '+
            'unlock purge reset change stop analyze cache flush optimize repair kill '+
            'install uninstall checksum restore check backup',
            'abs absolute acos action add adddate addtime aes_decrypt aes_encrypt after aggregate all allocate alter ' +
            'analyze and any are as asc ascii asin assertion at atan atan2 atn2 authorization authors avg backup ' +
            'before begin benchmark between bin binlog bit_and bit_count bit_length bit_or bit_xor both by ' +
            'cache call cascade cascaded case cast catalog ceil ceiling chain change changed char_length ' +
            'character_length charindex charset check checksum checksum_agg choose close coalesce ' +
            'coercibility collate collation collationproperty column columns columns_updated commit compress concat ' +
            'concat_ws concurrent connect connection connection_id consistent constraint constraints continue ' +
            'contributors conv convert convert_tz corresponding cos cot count count_big crc32 create cross cume_dist ' +
            'curdate current current_date current_time current_timestamp current_user cursor curtime data database ' +
            'databases datalength date_add date_format date_sub dateadd datediff datefromparts datename ' +
            'datepart datetime2fromparts datetimeoffsetfromparts day dayname dayofmonth dayofweek dayofyear ' +
            'deallocate declare decode default deferrable deferred degrees delayed delete des_decrypt ' +
            'des_encrypt des_key_file desc describe descriptor diagnostics difference disconnect distinct ' +
            'distinctrow div do domain double drop dumpfile each else elt enclosed encode encrypt end end-exec ' +
            'engine engines eomonth errors escape escaped event eventdata events except exception exec execute ' +
            'exists exp explain export_set extended external extract fast fetch field fields find_in_set ' +
            'first first_value floor flush for force foreign format found found_rows from from_base64 ' +
            'from_days from_unixtime full function get get_format get_lock getdate getutcdate global go goto grant ' +
            'grants greatest group group_concat grouping grouping_id gtid_subset gtid_subtract handler having help ' +
            'hex high_priority hosts hour ident_current ident_incr ident_seed identified identity if ifnull ignore ' +
            'iif ilike immediate in index indicator inet6_aton inet6_ntoa inet_aton inet_ntoa infile initially inner ' +
            'innodb input insert install instr intersect into is is_free_lock is_ipv4 ' +
            'is_ipv4_compat is_ipv4_mapped is_not is_not_null is_used_lock isdate isnull isolation join key kill ' +
            'language last last_day last_insert_id last_value lcase lead leading least leaves left len lenght level ' +
            'like limit lines ln load load_file local localtime localtimestamp locate lock log log10 log2 logfile ' +
            'logs low_priority lower lpad ltrim make_set makedate maketime master master_pos_wait match matched max ' +
            'md5 medium merge microsecond mid min minute mod mode module month monthname mutex name_const names ' +
            'national natural nchar next no no_write_to_binlog not now nullif nvarchar oct ' +
            'octet_length of old_password on only open optimize option optionally or ord order outer outfile output ' +
            'pad parse partial partition password patindex percent_rank percentile_cont percentile_disc period_add ' +
            'period_diff pi plugin position pow power pragma precision prepare preserve primary prior privileges ' +
            'procedure procedure_analyze processlist profile profiles public publishingservername purge quarter ' +
            'query quick quote quotename radians rand read references regexp relative relaylog release ' +
            'release_lock rename repair repeat replace replicate reset restore restrict return returns reverse ' +
            'revoke right rlike rollback rollup round row row_count rows rpad rtrim savepoint schema scroll ' +
            'sec_to_time second section select serializable server session session_user set sha sha1 sha2 share ' +
            'show sign sin size slave sleep smalldatetimefromparts snapshot some soname soundex ' +
            'sounds_like space sql sql_big_result sql_buffer_result sql_cache sql_calc_found_rows sql_no_cache ' +
            'sql_small_result sql_variant_property sqlstate sqrt square start starting status std ' +
            'stddev stddev_pop stddev_samp stdev stdevp stop str str_to_date straight_join strcmp string stuff ' +
            'subdate substr substring subtime subtring_index sum switchoffset sysdate sysdatetime sysdatetimeoffset ' +
            'system_user sysutcdatetime table tables tablespace tan temporary terminated tertiary_weights then time ' +
            'time_format time_to_sec timediff timefromparts timestamp timestampadd timestampdiff timezone_hour ' +
            'timezone_minute to to_base64 to_days to_seconds todatetimeoffset trailing transaction translation ' +
            'trigger trigger_nestlevel triggers trim truncate try_cast try_convert try_parse ucase uncompress ' +
            'uncompressed_length unhex unicode uninstall union unique unix_timestamp unknown unlock update upgrade ' +
            'upped upper usage use user user_resources using utc_date utc_time utc_timestamp uuid uuid_short ' +
            'validate_password_strength value values var var_pop var_samp variables variance varp ' +
            'version view warnings week weekday weekofyear weight_string when whenever where with work write xml ' +
            'xor year yearweek zon',
            'true false null',
            'array bigint binary bit blob boolean char character date dec decimal float int integer interval number ' +
            'numeric real serial smallint varchar varying int8 serial8 text'
          ";
    }
}