package com.example.cinetec.ScreenApp;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.LinearLayout;

import com.example.cinetec.DB.Db_helper;
import com.example.cinetec.R;
import com.example.cinetec.customviews.CinemaSelection;
import com.example.cinetec.entities.Cinema;
import com.example.cinetec.state.State;

import java.util.ArrayList;
import java.util.Timer;
import java.util.TimerTask;

public class Cinema_select extends AppCompatActivity {
    private LayoutInflater inflater;
    private LinearLayout BranchesList;
    private Timer timer;

    /**
     * its called when the view its created
     * @param savedInstanceState
     */
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cinema_select);
        inflater=(LayoutInflater) this.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        BranchesList=this.findViewById(R.id.cinema_linear_layout);
        getCinema();

    }

    /**
     * its called when the activity comes back to the foreground
     */
    @Override
    protected void onResume() {
        super.onResume();
        final Handler handler = new Handler();
        this.timer = new Timer();
        TimerTask doTask = new TimerTask() {
            @Override
            public void run() {
                handler.post(new Runnable() {
                    @SuppressWarnings("unchecked")
                    public void run() {
                        try {
                            Log.d("UPDATE","Reiniciando APP");
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
        this.timer.schedule(doTask, 30000);
    }

    /**
     * Add a new cinema icon
     * @param text String cinema name
     */
    public void add_branch(String text){
        CinemaSelection cinema=new CinemaSelection(this);
        cinema.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                State current_state=State.getInstance();
                current_state.setCinema_name(text);
                go_to_movies();

            }
        });
        cinema.set_text(text);
        BranchesList.addView(cinema);


    }

    /**
     * Get the cinema from the backend, and draws it
     */
    public void getCinema(){
        Db_helper helper=new Db_helper(this);
        ArrayList<Cinema> cinemas=helper.getCinemas();
        if(cinemas==null)return;
        Log.d("LARgo",Integer.toString(cinemas.size()));
        Log.d("asdfasdfasdfsadf",cinemas.get(0).getCinema_name());
        for(int i=0;i<cinemas.size();i++){
            add_branch(cinemas.get(i).getCinema_name());

        }

    }

    /**
     * Goes to the movies activity
     */
    public void go_to_movies(){
        timer.cancel();
        timer.purge();
        Intent switchActivityIntent = new Intent(this, Movie_selection.class);
        startActivity(switchActivityIntent);
    }

    /**
     * Action called when the back its pressed
     */
    @Override
    public void onBackPressed() {
        timer.cancel();
        timer.purge();
        super.onBackPressed();
    }
}