CREATE MIGRATION m1lwkasx7yzh3t5dtt6lrgvikom7hhshgcelzxu4qku2fbhoqooioq
    ONTO m1ueho227jwsomgc7v6ciaqu3f7x3lhqvrirjkeschtysg3w2cov2a
{
  ALTER TYPE default::Contact {
      DROP PROPERTY date_of_birth;
  };
  ALTER TYPE default::Contact {
      CREATE PROPERTY ddate_of_birth: cal::local_date;
  };
};
