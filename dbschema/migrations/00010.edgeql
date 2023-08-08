CREATE MIGRATION m12p5l2mbdauy4li7rnedhd3nn57cutwztdi36xko77ue45u23lsbq
    ONTO m1q4jidlk2lkivb4wwxyqtoynubg2txeez3osc3fcld345om5no7hq
{
  ALTER TYPE default::Contact {
      ALTER PROPERTY date_of_birth {
          SET TYPE cal::local_date USING (<cal::local_date>.date_of_birth);
      };
      ALTER PROPERTY first_name {
          RESET OPTIONALITY;
      };
      ALTER PROPERTY last_name {
          RESET OPTIONALITY;
      };
      ALTER PROPERTY role {
          RESET OPTIONALITY;
      };
      ALTER PROPERTY title {
          RESET OPTIONALITY;
      };
  };
};
