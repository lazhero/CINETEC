package com.example.cinetec.ScreenApp;


import androidx.appcompat.app.AppCompatActivity;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.view.View;
import com.example.cinetec.DB.Db_helper;
import com.example.cinetec.R;
import com.example.cinetec.services.DataUpdate;
import com.example.cinetec.state.State;
import com.google.android.material.button.MaterialButton;
import com.google.android.material.textfield.TextInputEditText;



public class Login_Activity extends AppCompatActivity {
    TextInputEditText user;
    TextInputEditText password;
    MaterialButton log;
    Db_helper DB;

    /**
     * Method called when its view its created
     * @param savedInstanceState
     */
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        user=findViewById(R.id.login_entry_user);
        password=findViewById(R.id.login_entry_password);
        log=findViewById(R.id.login_button);
        log.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                LoginAttempt();
            }
        });
        Intent intent=new Intent(this, DataUpdate.class);
        startService(intent);
        DB=new Db_helper(this);






    }

    /**
     * Login attemp, when login button its pressed
     */
    public void LoginAttempt(){
        String username=this.user.getText().toString();
        String password=this.password.getText().toString();
        boolean logCondition=DB.verifyClient(username,password);
       if(logCondition){
            State state=State.getInstance();
            state.setUsername(username);
            Intent switchActivityIntent = new Intent(this, Cinema_select.class);
            startActivity(switchActivityIntent);
        }



    }
}