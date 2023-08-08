CREATE MIGRATION m1exw56xazoqccklzdtyt6bz6gzan4mpsyyl762izcxf6svillrf5a
    ONTO m1jcc624mci36dabptcs7f5sidqruxuyq65omzybsx4zan6xbliu4q
{
  ALTER TYPE default::Contact {
      ALTER PROPERTY date_of_birth {
          SET TYPE std::str USING (<std::str>.date_of_birth);
      };
  };
};
