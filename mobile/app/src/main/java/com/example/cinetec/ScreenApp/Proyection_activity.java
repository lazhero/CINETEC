package com.example.cinetec.ScreenApp;

import androidx.annotation.Dimension;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.util.Log;
import android.view.ContextThemeWrapper;
import android.view.Gravity;
import android.view.View;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.example.cinetec.DB.Db_helper;
import com.example.cinetec.R;
import com.example.cinetec.entities.Projection;
import com.example.cinetec.state.State;
import com.google.android.material.button.MaterialButton;

import java.util.ArrayList;
import java.util.Timer;
import java.util.TimerTask;

public class Proyection_activity extends AppCompatActivity {
    private LinearLayout linear;
    private Db_helper DB=new Db_helper(this);
    private State state=State.getInstance();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.proyection_activity);
        linear=(LinearLayout) findViewById(R.id.projection_linear_layout);
        just_prove();
        final Handler handler = new Handler();
        Timer timer = new Timer();
        TimerTask doTask = new TimerTask() {
            @Override
            public void run() {
                handler.post(new Runnable() {
                    @SuppressWarnings("unchecked")
                    public void run() {
                        try {
                            Intent intent = getIntent();
                            finish();
                            startActivity(intent);
                        }
                        catch (Exception e) {
                            // TODO Auto-generated catch block
                        }
                    }
                });
            }
        };
        timer.schedule(doTask, 30000, 30000);



    }
    public void just_prove() {
        Log.d("Cinema name",state.getCinema_name());
        Log.d("Movie name",state.getMovie_original_name());
        ArrayList<Projection> projections=DB.getProjection(state.getMovie_original_name(),state.getCinema_name());
        if(projections==null){
            non_available_projections();
        }
        else{
            for(int i=0,size=projections.size();i<size;i++){
                add_projection(projections.get(i));
            }
        }



    }
    public void non_available_projections(){
        TextView text=new TextView(this);
        text.setText("NO PROJECTIONS AVAILABLE");
        text.setGravity(Gravity.CENTER_HORIZONTAL);
        text.setTextSize(Dimension.SP,40);
        text.setTextColor(getResources().getColor(R.color.white));
        linear.addView(text);

    }

    public void add_projection(Projection projection){
        String text=projection.getDate()+"  "+projection.getInitial_time()+"  "+projection.getRoom_Number();
        int buttonStyle = R.style.projection_button_style;
        MaterialButton button = new MaterialButton(new ContextThemeWrapper(this, buttonStyle), null, buttonStyle);
        button.setText(text);
        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                state.setProjection_id(projection.getId());
                go_to_seats();
            }

        });
        linear.addView(button);
    }
    public void go_to_seats(){
        Intent switchActivityIntent = new Intent(this, Seat_activity.class);
        startActivity(switchActivityIntent);
    }
}