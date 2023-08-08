CREATE MIGRATION m1fmz3mdrchhzckct2rffilqymikym2jsypzwagszqapmia7f3vica
    ONTO initial
{
  CREATE TYPE default::Contact {
      CREATE PROPERTY date_of_birth: cal::local_date;
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
