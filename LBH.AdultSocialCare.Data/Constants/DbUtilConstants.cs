namespace LBH.AdultSocialCare.Data.Constants
{
    public static class DbUtilConstants
    {
        public const string CompareDates =
            @"CREATE OR REPLACE FUNCTION CompareDates(date1 timestamptz = null, date2 timestamptz = null) RETURNS int AS
                $$
                BEGIN
                    IF date1 IS NULL AND date2 IS NULL THEN
                        RETURN 0;
                    ELSIF date1 IS NULL AND date2 IS NOT NULL THEN
                        RETURN -1;
                    ELSIF date1 IS NOT NULL AND date2 IS NULL THEN
                        RETURN 1;
                    ELSIF date1::date > date2::date THEN
                        RETURN 1;
                    ELSIF date1::date < date2::date THEN
                        RETURN -1;
                    ELSE
                        RETURN 0;
                    END IF;
                END;
                $$ LANGUAGE plpgsql;";

        public const string DeleteCompareDates =
            @"DROP FUNCTION IF EXISTS CompareDates(date1 timestamptz, date2 timestamptz);";
    }
}
