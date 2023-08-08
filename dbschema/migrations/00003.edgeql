CREATE MIGRATION m1ivnfiv32c6xa7mfk4zhi2vg73kotnhkmlnhcbaknyfsnsktvzksq
    ONTO m1wffewt46grxhqwnegwqxirkpifwbthxonkqyvasmnxpbjiapomsa
{
  CREATE TYPE default::Contact {
      CREATE PROPERTY date_of_birth: std::datetime;
      CREATE PROPERTY description: std::str;
      CREATE REQUIRED PROPERTY email: std::str {
          CREATE CONSTRAINT std::exclusive;
      };
      CREATE REQUIRED PROPERTY first_name: std::str;
      CREATE PROPERTY is_married: std::bool;
      CREATE REQUIRED PROPERTY last_name: std::str;
      CREATE REQUIRED PROPERTY password: std::str;
      CREATE REQUIRED PROPERTY role: std::str;
      CREATE REQUIRED PROPERTY title: std::str;
      CREATE REQUIRED PROPERTY username: std::str {
          CREATE CONSTRAINT std::exclusive;
      };
  };
};
