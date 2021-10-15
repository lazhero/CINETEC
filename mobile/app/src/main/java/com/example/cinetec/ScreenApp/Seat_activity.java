package com.example.cinetec.ScreenApp;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.content.res.Resources;
import android.os.Bundle;
import android.os.Handler;
import android.util.Log;
import android.util.TypedValue;
import android.view.ContextThemeWrapper;
import android.view.View;
import android.widget.LinearLayout;

import com.example.cinetec.DB.Db_helper;
import com.example.cinetec.R;
import com.example.cinetec.customviews.Matrix_layout;
import com.example.cinetec.entities.Seat;
import com.example.cinetec.state.State;
import com.google.android.material.button.MaterialButton;

import java.util.ArrayList;
import java.util.Timer;
import java.util.TimerTask;

public class Seat_activity extends AppCompatActivity {
    Matrix_layout layout;
    MaterialButton buy_button;
    ArrayList<Integer> selected_seat;
    State state;
    final int freeSeat=0;
    final int occupiedSeat=1;
    final int covidSeat=2;
    private Timer timer;
    private Db_helper DB;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_seat);
        layout=(Matrix_layout) findViewById(R.id.seat_selecction_layout);
        buy_button=(MaterialButton)findViewById(R.id.select_seat_button);
        buy_button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                add_order();
            }
        });
        selected_seat=new ArrayList<>();
        state=State.getInstance();
        set_matrix(10);
        final Handler handler = new Handler();
        this.timer = new Timer();
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
        timer.schedule(doTask, 30000);
        justprove();

    }
    public void justprove(){
        DB=new Db_helper(this);
        ArrayList<Seat> seats=DB.getSeat(state.getProjection_id());
        if(seats==null)return;
        for(int i=0,size=seats.size();i<size;i++){
            Seat currentSeat=seats.get(i);
            switch (currentSeat.getState()){
                case freeSeat:
                    add_free_seat(currentSeat.getNumber());
                    break;
                case occupiedSeat:
                    add_occupied_seat();
                    break;
                case covidSeat:
                    add_restricted_seat();
                    break;
            }

        }


    }
    public void set_matrix(int rows){
        layout.setMax_per_row(rows);
    }

    public void add_free_seat(int seatNumber){
        MaterialButton button=create_seat();
        button.setIconTintResource(R.color.white);
        button.setOnClickListener(new View.OnClickListener() {
        final int number=seatNumber;
            @Override
            public void onClick(View view) {
                highlight(button,number);

            }
        });
        layout.add_view(button);
    }
    public void add_occupied_seat(){
        MaterialButton button=create_seat();
        button.setIconTintResource(R.color.gray);
        button.setEnabled(false);
        layout.add_view(button);
    }
    public void add_restricted_seat(){
        MaterialButton button=create_seat();
        button.setIconTintResource(R.color.red);
        button.setEnabled(false);
        layout.add_view(button);
    }
    /*
    public void add_selected_seat(){
        MaterialButton button=create_seat();
        button.setIconTintResource(R.color.yellow);

        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                off(button);
            }
        });
        layout.add_view(button);
    }

     */

    public void highlight(MaterialButton button,int seat_number){
        button.setIconTintResource(R.color.yellow);
        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                off(button,seat_number);
            }
        });
        selected_seat.add(seat_number);

    }
    public void off(MaterialButton button,int seat_number){
        button.setIconTintResource(R.color.white);
        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                highlight(button,seat_number);
            }
        });
        int index=selected_seat.indexOf(new Integer(seat_number));
        selected_seat.remove(index);
    }
    private MaterialButton create_seat(){
        int buttonStyle = R.style.free_seat;
        MaterialButton button = new MaterialButton(new ContextThemeWrapper(this, buttonStyle), null, buttonStyle);
        button.setBackgroundTintList(this.getResources().getColorStateList(R.color.black));
        button.setLayoutParams(new LinearLayout.LayoutParams(dp_px(33),dp_px(40)));
        return button;
    }

    private int dp_px(int measure){
        Resources r = this.getResources();
        int px = (int) TypedValue.applyDimension(
                TypedValue.COMPLEX_UNIT_DIP,
                measure,
                r.getDisplayMetrics()
        );
        return px;
    }
    private void add_order(){
        DB.Process_order(state.getUsername(),state.getProjection_id(),selected_seat);
       // DB.addOrder(state.getUsername(),state.getProjection_id());
       // int order=DB.getClientLastOrder();
       // for(int i=0;i<selected_seat.size();i++){

            //DB.insertReservedSeat(selected_seat.get(i),order);
            //DB.changeSeatState(state.getProjection_id(),selected_seat.get(i),occupiedSeat);
        //}
        //DB.SyncProcess();
    }

    @Override
    public void onBackPressed() {
        timer.cancel();
        timer.purge();
        super.onBackPressed();
    }
}