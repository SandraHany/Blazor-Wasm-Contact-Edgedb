CREATE MIGRATION m1fxi47sdnph66gfl4bbccmoam4nqm3nqd25o5oht3ygwcpnm4raea
    ONTO m12p5l2mbdauy4li7rnedhd3nn57cutwztdi36xko77ue45u23lsbq
{
  ALTER TYPE default::Contact {
      DROP PROPERTY date_of_birth;
  };
};
