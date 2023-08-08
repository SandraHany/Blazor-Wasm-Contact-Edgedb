CREATE MIGRATION m1j47veclygjbldrkox34hhu4ggvf44bkccneee4wrl4v3r4x7kyra
    ONTO m1exw56xazoqccklzdtyt6bz6gzan4mpsyyl762izcxf6svillrf5a
{
  ALTER TYPE default::Contact {
      ALTER PROPERTY date_of_birth {
          SET TYPE std::datetime USING (<std::datetime>.date_of_birth);
      };
  };
};
