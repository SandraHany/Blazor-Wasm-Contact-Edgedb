module default {
    type Contact {
        first_name: str;
        last_name: str;
        required email: str {
          constraint exclusive;
        };
        required username: str {
            constraint exclusive;
        };
        required password: str;
        role: str; 
        title: str;
        description: str;
        date_of_birth: cal::local_date;
        is_married: bool;
    }
}