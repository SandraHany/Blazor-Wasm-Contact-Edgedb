CREATE MIGRATION m1jcc624mci36dabptcs7f5sidqruxuyq65omzybsx4zan6xbliu4q
    ONTO m1ukzv3qpfro262jjk2wcdk7m4fmcuxtjknlvreiexor223dzkz2ia
{
  ALTER TYPE default::Contact {
      ALTER PROPERTY date_of_birth {
          SET TYPE std::datetime USING (<std::datetime>.date_of_birth);
      };
  };
};
