CREATE MIGRATION m1ueho227jwsomgc7v6ciaqu3f7x3lhqvrirjkeschtysg3w2cov2a
    ONTO m1fxi47sdnph66gfl4bbccmoam4nqm3nqd25o5oht3ygwcpnm4raea
{
  ALTER TYPE default::Contact {
      CREATE PROPERTY date_of_birth: std::datetime;
  };
};
