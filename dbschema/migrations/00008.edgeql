CREATE MIGRATION m1ohwoqe3ee5nt4owupdnawydhura4lrcityokshbszgvhvvp7j7tq
    ONTO m1j47veclygjbldrkox34hhu4ggvf44bkccneee4wrl4v3r4x7kyra
{
  ALTER TYPE default::Contact {
      ALTER PROPERTY date_of_birth {
          SET TYPE std::str USING (<std::str>.date_of_birth);
      };
  };
};
