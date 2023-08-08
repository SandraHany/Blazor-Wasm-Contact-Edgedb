CREATE MIGRATION m1ukzv3qpfro262jjk2wcdk7m4fmcuxtjknlvreiexor223dzkz2ia
    ONTO m1ivnfiv32c6xa7mfk4zhi2vg73kotnhkmlnhcbaknyfsnsktvzksq
{
  ALTER TYPE default::Contact {
      ALTER PROPERTY date_of_birth {
          SET TYPE std::str USING (<std::str>.date_of_birth);
      };
  };
};
