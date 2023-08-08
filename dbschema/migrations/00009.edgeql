CREATE MIGRATION m1q4jidlk2lkivb4wwxyqtoynubg2txeez3osc3fcld345om5no7hq
    ONTO m1ohwoqe3ee5nt4owupdnawydhura4lrcityokshbszgvhvvp7j7tq
{
  ALTER TYPE default::Contact {
      ALTER PROPERTY is_married {
          SET TYPE std::str USING (<std::str>.is_married);
      };
  };
};
