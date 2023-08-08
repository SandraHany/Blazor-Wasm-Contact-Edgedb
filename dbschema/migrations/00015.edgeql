CREATE MIGRATION m1qn4hlccw2tleyqgtumt2t3sgkqysqrss47xsv2b7c7lcrhawnboq
    ONTO m1nq2b7slobjlukd3sxaz7tgbsxbei4n7vcrdpjbwgtdevlinbzytq
{
  ALTER TYPE default::Contact {
      ALTER PROPERTY is_married {
          SET TYPE std::bool USING (<std::bool>.is_married);
      };
  };
};
