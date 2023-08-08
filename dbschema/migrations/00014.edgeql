CREATE MIGRATION m1nq2b7slobjlukd3sxaz7tgbsxbei4n7vcrdpjbwgtdevlinbzytq
    ONTO m1lwkasx7yzh3t5dtt6lrgvikom7hhshgcelzxu4qku2fbhoqooioq
{
  ALTER TYPE default::Contact {
      ALTER PROPERTY ddate_of_birth {
          RENAME TO date_of_birth;
      };
  };
};
